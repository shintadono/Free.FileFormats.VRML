using System;
using System.Globalization;
using System.Text;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		#region Consume WhiteSpaces
		void ConsumeDOSNewLine()
		{
			if(!stream.EndOfStream)
			{
				int peek=stream.Peek();
				if(peek==-1) ErrorUnexpectedEndOfStream();
				char n=(char)peek;
				if(n=='\n') stream.Read();
			}
		}

		// Returns comment without newline or carrage return
		string ConsumeComment()
		{
			StringBuilder ret=new StringBuilder();

			while(!stream.EndOfStream)
			{
				int peek=stream.Peek();
				if(peek==-1) ErrorUnexpectedEndOfStream();

				stream.Read();

				char c=(char)peek;

				if(c=='\r'||c=='\n')
				{
					// check for newline after carrage return
					if(c=='\r') ConsumeDOSNewLine();
					line++;

					break;
				}

				ret.Append(c);
			}

			return ret.ToString();
		}

		void ConsumeWhiteSpaces()
		{
			if(progressInfo!=null&&line-lastProgressInfoLine>progressInfoLineDelta)
			{
				if(!progressInfo(stream.BaseStream.Position*100.0/stream.BaseStream.Length))
					throw new UserCancellationException();

				lastProgressInfoLine=line;
			}

			while(!stream.EndOfStream)
			{
				int peek=stream.Peek();
				if(peek==-1) ErrorUnexpectedEndOfStream();

				char c=(char)peek;

				// The carriage return (0x0d), linefeed (0x0a), space (0x20), tab (0x09), and comma (0x2c) characters are whitespace characters
				if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n')
				{
					stream.Read();

					// check for newline after carrage return
					if(c=='\r') ConsumeDOSNewLine();
					if(c=='\r'||c=='\n') line++;

					continue;
				}

				// Comment
				if(c=='#')
				{
					stream.Read();

					ConsumeComment();

					continue;
				}

				if(c<0x20||c==0x7f) ErrorParsingToken("legal character", c);

				return;
			}
		}
		#endregion

		#region Consume Other Symbols
		// Returns Id
		string ConsumeId(bool colonIsTerminalSymbol)
		{
			StringBuilder ret=new StringBuilder();

			bool first=true;

			while(!stream.EndOfStream)
			{
				int peek=stream.Peek();
				if(peek==-1) ErrorUnexpectedEndOfStream();

				char c=(char)peek;

				if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n') break; // WhiteSpaces

				if(c=='"'||c=='#'||c=='\''||c=='.'||c=='['||c=='\\'||c==']'||c=='{'||c=='}')
					break; // Terminal symbols

				if(colonIsTerminalSymbol&&c==':') break; // Terminal symbols

				if(c<0x20||c==0x7f) ErrorParsingToken("legal character", c);

				if(first&&((c>='0'&&c<='9')||c=='+'||c=='-')) break; // digits or signs not as leading characters allowed

				stream.Read();

				first=false;

				ret.Append(c);
			}

			return ret.ToString();
		}

		// Returns Int32
		int ConsumeInt32()
		{
			// ([+\-]?(([0-9]+)|(0[xX][0-9a-fA-F]+)))

			#region [+\-]?
			int peekSign=stream.Peek();
			if(peekSign==-1) ErrorUnexpectedEndOfStream();

			char cSign=(char)peekSign;

			bool positive=true;
			if(cSign=='+'||cSign=='-')
			{
				stream.Read();
				if(cSign=='-') positive=false;
			}
			#endregion

			#region 0[xX]?
			bool isHex=false;
			bool wasZero=false;
			int peek0=stream.Peek();
			if(peek0==-1) ErrorUnexpectedEndOfStream();

			char c0=(char)peek0;

			if(c0=='0')
			{
				stream.Read();
				// do not save the zero, cause it might not be necessary
				wasZero=true;

				int peekX=stream.Peek();
				if(peekX==-1) ErrorUnexpectedEndOfStream();

				char cX=(char)peekX;

				if(cX=='x'||cX=='X')
				{
					stream.Read();
					// do not save the X, cause is not necessary

					isHex=true;
				}
			}
			#endregion

			if(isHex)
			{
				#region [0-9a-fA-F]+
				StringBuilder ret=new StringBuilder();

				bool wasHexDigit=false;
				for(; ; )
				{
					int peek=stream.Peek();
					if(peek==-1) ErrorUnexpectedEndOfStream();

					char c=(char)peek;

					if((c>='0'&&c<='9')||(c>='a'&&c<='f')||(c>='A'&&c<='F'))
					{
						stream.Read();
						ret.Append(c);
						wasHexDigit=true;
						continue;
					}

					if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

					ErrorParsingToken("int32 (hex)", c);
					return 0;
				}

				if(!wasHexDigit)
				{
					ErrorParsingToken("int32 (hex)");
					return 0;
				}

				int value=int.Parse(ret.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier, nc);

				return positive?value:-value; // make negative if not positive
				#endregion
			}
			else
			{
				#region [0-9]+
				StringBuilder ret=new StringBuilder();
				if(!positive) ret.Append('-'); // negative is possible
				if(wasZero) ret.Append('0');

				bool wasDigit=wasZero;
				for(; ; )
				{
					int peek=stream.Peek();
					if(peek==-1) ErrorUnexpectedEndOfStream();

					char c=(char)peek;

					if(c>='0'&&c<='9')
					{
						stream.Read();
						ret.Append(c);
						continue;
					}

					if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

					ErrorParsingToken("int32", c);
					return 0;
				}

				if(!wasDigit)
				{
					ErrorParsingToken("int32");
					return 0;
				}

				return int.Parse(ret.ToString(), nc);
				#endregion
			}
		}

		// Returns Float
		double ConsumeDouble()
		{
			// ([+/-]?((([0-9]+(\.)?)|([0-9]*\.[0-9]+))([eE][+\-]?[0-9]+)?))

			StringBuilder ret=new StringBuilder();

			#region [+/-]?
			int peekSign=stream.Peek();
			if(peekSign==-1) ErrorUnexpectedEndOfStream();

			char cSign=(char)peekSign;

			if(cSign=='+'||cSign=='-')
			{
				ret.Append(cSign);
				stream.Read();
			}
			#endregion

			#region ( ([0-9]+(\.)?) | ([0-9]*\.[0-9]+) )
			bool wasPeriod=false;
			bool wasDigit=false;
			for(; ; )
			{
				int peek=stream.Peek();
				if(peek==-1) ErrorUnexpectedEndOfStream();

				char c=(char)peek;

				if(c>='0'&&c<='9')
				{
					stream.Read();
					ret.Append(c);
					wasDigit=true;
					continue;
				}

				if(!wasPeriod&&c=='.')
				{
					stream.Read();
					ret.Append(c);
					wasPeriod=true;
					continue;
				}

				if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

				if(c=='e'||c=='E') break;

				ErrorParsingToken("float", c);
				return 0;
			}

			if(!wasDigit)
			{
				ErrorParsingToken("float");
				return 0;
			}
			#endregion

			#region ([eE][+\-]?[0-9]+)?
			int peekE=stream.Peek();
			if(peekE==-1) ErrorUnexpectedEndOfStream();

			char cE=(char)peekE;

			if(cE=='e'||cE=='E')
			{
				ret.Append(cE);
				stream.Read();

				// [+/-]?
				peekSign=stream.Peek();
				if(peekSign==-1) ErrorUnexpectedEndOfStream();

				cSign=(char)peekSign;

				if(cSign=='+'||cSign=='-')
				{
					ret.Append(cSign);
					stream.Read();
				}

				// [0-9]+
				wasDigit=false;
				for(; ; )
				{
					int peek=stream.Peek();
					if(peek==-1) ErrorUnexpectedEndOfStream();

					char c=(char)peek;

					if(c>='0'&&c<='9')
					{
						stream.Read();
						ret.Append(c);
						wasDigit=true;
						continue;
					}

					if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

					ErrorParsingToken("float", c);
					return 0;
				}

				if(!wasDigit)
				{
					ErrorParsingToken("float");
					return 0;
				}
			}
			#endregion

			return double.Parse(ret.ToString(), nc);
		}

		// Returns Int32 or Float
		object ConsumeNumber()
		{
			// ([+\-]?(([0-9]+)|(0[xX][0-9a-fA-F]+)))
			// or
			// ([+/-]?((([0-9]+(\.)?)|([0-9]*\.[0-9]+))([eE][+\-]?[0-9]+)?))

			#region [+\-]?
			bool positive=true;
			int peekSign=stream.Peek();
			if(peekSign==-1) ErrorUnexpectedEndOfStream();

			char cSign=(char)peekSign;

			if(cSign=='+'||cSign=='-')
			{
				stream.Read();
				if(cSign=='-') positive=false;

				// check for [+|-]Infinity
				int peekI=stream.Peek();
				if(peekI==-1) ErrorUnexpectedEndOfStream();
				char cI=(char)peekI;
				if(cI=='i'||cI=='I')
				{
					StringBuilder ret=new StringBuilder();
					for(; ; )
					{
						int peek=stream.Peek();
						if(peek==-1) ErrorUnexpectedEndOfStream();

						char c=(char)peek;

						if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

						stream.Read();
						ret.Append(c);
					}

					string infinity=ret.ToString();
					if(infinity.ToLower()!="infinity") ErrorParsingToken("float", infinity);

					return positive?double.PositiveInfinity:double.NegativeInfinity;
				}
			}
			#endregion

			#region 0[xX]?
			bool isHex=false;
			bool wasZero=false;
			int peek0=stream.Peek();
			if(peek0==-1) ErrorUnexpectedEndOfStream();

			char c0=(char)peek0;

			if(c0=='0')
			{
				stream.Read();
				// do not save the zero, cause it might not be necessary
				wasZero=true;

				int peekX=stream.Peek();
				if(peekX==-1) ErrorUnexpectedEndOfStream();

				char cX=(char)peekX;

				if(cX=='x'||cX=='X')
				{
					stream.Read();
					// do not save the X, cause is not necessary

					isHex=true;
				}
			}
			#endregion

			if(isHex)
			{
				#region [0-9a-fA-F]+
				StringBuilder ret=new StringBuilder();

				bool wasHexDigit=false;
				for(; ; )
				{
					int peek=stream.Peek();
					if(peek==-1) ErrorUnexpectedEndOfStream();

					char c=(char)peek;

					if((c>='0'&&c<='9')||(c>='a'&&c<='f')||(c>='A'&&c<='F'))
					{
						stream.Read();
						ret.Append(c);
						wasHexDigit=true;
						continue;
					}

					if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

					ErrorParsingToken("int32 (hex)", c);
					return 0;
				}

				if(!wasHexDigit)
				{
					ErrorParsingToken("int32 (hex)");
					return 0;
				}

				int value=int.Parse(ret.ToString(), NumberStyles.AllowHexSpecifier, nc);

				return positive?value:-value; // make negative if not positive
				#endregion
			}
			else
			{
				StringBuilder ret=new StringBuilder();
				if(!positive) ret.Append('-'); // negative is possible

				#region ( ([0-9]+(\.)?) | ([0-9]*\.[0-9]+) )
				if(wasZero) ret.Append('0');

				bool wasDigit=wasZero;
				bool wasPeriod=false;
				for(; ; )
				{
					int peek=stream.Peek();
					if(peek==-1) ErrorUnexpectedEndOfStream();

					char c=(char)peek;

					if(c>='0'&&c<='9')
					{
						stream.Read();
						ret.Append(c);
						wasDigit=true;
						continue;
					}

					if(!wasPeriod&&c=='.')
					{
						stream.Read();
						ret.Append(c);
						wasPeriod=true;
						continue;
					}

					if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

					if(c=='e'||c=='E') break;

					ErrorParsingToken(wasPeriod?"float":"number", c);
					return 0;
				}

				if(!wasDigit)
				{
					ErrorParsingToken(wasPeriod?"float":"number");
					return 0;
				}
				#endregion

				#region ([eE][+\-]?[0-9]+)?
				bool hasExponent=false;
				int peekE=stream.Peek();
				if(peekE==-1) ErrorUnexpectedEndOfStream();

				char cE=(char)peekE;

				if(cE=='e'||cE=='E')
				{
					ret.Append(cE);
					stream.Read();
					hasExponent=true;

					// [+/-]?
					peekSign=stream.Peek();
					if(peekSign==-1) ErrorUnexpectedEndOfStream();

					cSign=(char)peekSign;

					if(cSign=='+'||cSign=='-')
					{
						ret.Append(cSign);
						stream.Read();
					}

					// [0-9]+
					wasDigit=false;
					for(; ; )
					{
						int peek=stream.Peek();
						if(peek==-1) ErrorUnexpectedEndOfStream();

						char c=(char)peek;

						if(c>='0'&&c<='9')
						{
							stream.Read();
							ret.Append(c);
							wasDigit=true;
							continue;
						}

						if(c=='\t'||c==' '||c==','||c=='\r'||c=='\n'||c=='#'||c=='}'||c==']') break;

						ErrorParsingToken("float", c);
					}

					if(!wasDigit)
					{
						ErrorParsingToken("float");
						return 0;
					}
				}

				#endregion

				if(!wasPeriod&&!hasExponent)
				{
					int number=0;
					if(int.TryParse(ret.ToString(), NumberStyles.Integer, nc, out number)) return number;
				}

				return double.Parse(ret.ToString(), nc);
			}
		}

		int GetIntNumber(object value)
		{
			if(value is int) return (int)value;
			ErrorParsingToken("int32", value.ToString());
			return 0;
		}

		double GetFloatNumber(object value)
		{
			if(value is double) return (double)value;
			return (double)(int)value;
		}

		// Returns string without double-quotes
		string ConsumeString()
		{
			#region Read Double-Quote
			int peekDQ=stream.Peek();
			if(peekDQ==-1) ErrorUnexpectedEndOfStream();
			if((char)peekDQ!='"')
			{
				ErrorParsingToken("string", (char)peekDQ);
				return "";
			}

			stream.Read();
			#endregion

			StringBuilder ret=new StringBuilder();

			for(; ; )
			{
				int peek=stream.Peek();
				if(peek==-1)
				{
					ErrorUnexpectedEndOfStream();
					return "";
				}

				char c=(char)peek;

				stream.Read();

				if(c=='"') return ret.ToString(); // done

				// check for newline after carrage return
				if(c=='\r') ConsumeDOSNewLine();
				if(c=='\r'||c=='\n') line++;

				if(c=='\\') // Escape
				{
					int peekEsc=stream.Peek();
					if(peekEsc==-1)
					{
						ErrorUnexpectedEndOfStream();
						return "";
					}

					char cEsc=(char)peekEsc;

					stream.Read();

					if(cEsc!='"'&&cEsc!='\\') ret.Append('\\');

					ret.Append(cEsc);
				}

				ret.Append(c);
			}
		}
		#endregion

		#region Cosume-, Return- or Peek-Token
		object returnedToken=null;
		object ConsumeNextToken(bool periodIsTerminalSymbol, bool colonIsTerminalSymbol, bool parseStatements)
		{
			if(returnedToken!=null)
			{
				object returnToken=returnedToken;
				returnedToken=null;
				return returnToken;
			}

			while(!stream.EndOfStream)
			{
				int peek=stream.Peek();
				if(peek==-1)
				{
					ErrorUnexpectedEndOfStream();
					return null;
				}

				char c=(char)peek;

				switch(c)
				{
					case '#':
					case '\n':
					case '\r':
					case '\t':
					case ',':
					case ' ': ConsumeWhiteSpaces(); break;
					case '"': return new VRMLTokenString(ConsumeString());
					case '{':
					case '}':
					case '[':
					case ']': stream.Read(); return new VRMLTokenTerminalSymbol(c);
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case '+':
					case '-': return new VRMLTokenNumber(ConsumeNumber());
					case '.': // first char of a number or terminal symbol?
						if(!periodIsTerminalSymbol) return new VRMLTokenNumber(ConsumeNumber());

						stream.Read();
						return new VRMLTokenTerminalSymbol(c);
					case ':': // first char of a Id symbol?
						if(!colonIsTerminalSymbol) return new VRMLTokenIdKeywordOrFieldType(ConsumeId(colonIsTerminalSymbol));

						stream.Read();
						return new VRMLTokenTerminalSymbol(c);
					default: return new VRMLTokenIdKeywordOrFieldType(ConsumeId(colonIsTerminalSymbol));
				}
			}

			if(parseStatements) return null; // End of Stream; no Exception here because ParseStatements ends if null

			ErrorUnexpectedEndOfStream();
			return null;
		}

		void ReturnToken(object token)
		{
			if(returnedToken!=null) throw new Exception("Multiple tokens returned.");
			returnedToken=token;
		}

		internal object PeekNextToken()
		{
			object token=ConsumeNextToken(false, false, false);
			ReturnToken(token);
			return token;
		}

		internal string GetNextIDToken()
		{
			return GetNextIDToken(false);
		}

		internal string GetNextIDToken(bool colonIsTerminalSymbol)
		{
			object token=ConsumeNextToken(false, colonIsTerminalSymbol, false);
			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("keyword or id", token);

			return idToken.id;
		}

		internal char GetNextTerminalSymbolToken()
		{
			object token=ConsumeNextToken(false, false, false);
			VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
			if(tsToken==null) ErrorParsingToken("terminal symbol", token);

			return tsToken.symbol;
		}

		internal char GetNextPeriodToken()
		{
			object token=ConsumeNextToken(true, false, false);
			VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
			if(tsToken==null||tsToken.symbol!='.') ErrorParsingToken(".", token);

			return tsToken.symbol;
		}

		internal char GetNextColonToken()
		{
			object token=ConsumeNextToken(false, true, false);
			VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
			if(tsToken==null||tsToken.symbol!=':') ErrorParsingToken(":", token);

			return tsToken.symbol;
		}

		internal string GetNextStringToken()
		{
			object token=ConsumeNextToken(false, false, false);
			VRMLTokenString stringToken=token as VRMLTokenString;
			if(stringToken==null) ErrorParsingToken("string", token);

			return stringToken.text;
		}

		internal object GetNextNumberToken()
		{
			object token=ConsumeNextToken(false, false, false);
			VRMLTokenNumber numberToken=token as VRMLTokenNumber;
			if(numberToken==null)
			{
				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken!=null)
				{
					string id=idToken.id.ToLower();
					if(id=="infinity") return double.PositiveInfinity;
					if(id=="nan") return double.NaN;
				}

				ErrorParsingToken("number", token);
			}

			return numberToken.number;
		}

		internal FieldType GetNextFieldTypeToken()
		{
			object token=ConsumeNextToken(false, false, false);
			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("fieldType", token);

			switch(idToken.id)
			{
				case "MFBool": return FieldType.MFBool;
				case "MFColor": return FieldType.MFColor;
				case "MFColorRGBA": return FieldType.MFColorRGBA;
				case "MFDouble": return FieldType.MFFloat;
				case "MFFloat": return FieldType.MFFloat;
				case "MFImage": return FieldType.MFImage;
				case "MFInt32": return FieldType.MFInt32;
				case "MFMatrix3d":
				case "MFMatrix3f": return FieldType.MFMatrix3f;
				case "MFMatrix4d":
				case "MFMatrix4f": return FieldType.MFMatrix4f;
				case "MFNode": return FieldType.MFNode;
				case "MFRotation": return FieldType.MFRotation;
				case "MFString": return FieldType.MFString;
				case "MFTime": return FieldType.MFTime;
				case "MFVec2d":
				case "MFVec2f": return FieldType.MFVec2f;
				case "MFVec3f":
				case "MFVec3d": return FieldType.MFVec3f;
				case "MFVec4d":
				case "MFVec4f": return FieldType.MFVec4f;
				case "SFBool": return FieldType.SFBool;
				case "SFColor": return FieldType.SFColor;
				case "SFColorRGBA": return FieldType.SFColorRGBA;
				case "SFDouble":
				case "SFFloat": return FieldType.SFFloat;
				case "SFImage": return FieldType.SFImage;
				case "SFInt32": return FieldType.SFInt32;
				case "SFMatrix3d":
				case "SFMatrix3f": return FieldType.SFMatrix3f;
				case "SFMatrix4d":
				case "SFMatrix4f": return FieldType.SFMatrix4f;
				case "SFNode": return FieldType.SFNode;
				case "SFRotation": return FieldType.SFRotation;
				case "SFString": return FieldType.SFString;
				case "SFTime": return FieldType.SFTime;
				case "SFVec2d":
				case "SFVec2f": return FieldType.SFVec2f;
				case "SFVec3d":
				case "SFVec3f": return FieldType.SFVec3f;
				case "SFVec4d":
				case "SFVec4f": return FieldType.SFVec4f;
				default: ErrorParsingToken("fieldType", idToken.id);
					return FieldType.SFInt32; // dummy to silence the compiler
			}
		}
		#endregion
	}
}
