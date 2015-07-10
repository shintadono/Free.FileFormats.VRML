using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Nodes;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		#region FieldParser
		internal bool ParseBoolValue()
		{
			try
			{
				string tokenBool=GetNextIDToken();

				if(tokenBool=="TRUE") return true;
				if(tokenBool=="FALSE") return false;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFBoolInvalid, ex);
			}

			ErrorParsingField(VRMLReaderError.SFBoolInvalid);

			return false;
		}

		internal double ParseDoubleValue()
		{
			try
			{
				return GetFloatNumber(GetNextNumberToken());
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFFloatInvalid, ex);
			}

			return 0;
		}

		internal int ParseIntValue()
		{
			try
			{
				return GetIntNumber(GetNextNumberToken());
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFInt32Invalid, ex);
			}

			return 0;
		}

		internal string ParseStringValue()
		{
			try
			{
				return GetNextStringToken();
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFStringInvalid, ex);
			}

			return "";
		}
		#endregion

		#region ArrayParser
		internal List<bool> ParseSFBoolOrMFBoolValue()
		{
			// sfboolValue | [ ] | [ sfboolValues ]

			try
			{
				object token=PeekNextToken();

				List<bool> ret=new List<bool>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseBoolValue());
					}
				}
				else ret.Add(ParseBoolValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFBoolInvalid, ex);
			}

			return null;
		}

		internal List<SFColor> ParseSFColorOrMFColorValue()
		{
			// sfcolorValue | [ ] | [ sfcolorValues ]

			try
			{
				object token=PeekNextToken();

				List<SFColor> ret=new List<SFColor>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFColorValue());
					}
				}
				else ret.Add(ParseSFColorValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFColorInvalid, ex);
			}

			return null;
		}

		internal List<SFColorRGBA> ParseSFColorRGBAOrMFColorRGBAValue()
		{
			// sfcolorRGBAValue | [ ] | [ sfcolorRGBAValues ]

			try
			{
				object token=PeekNextToken();

				List<SFColorRGBA> ret=new List<SFColorRGBA>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFColorRGBAValue());
					}
				}
				else ret.Add(ParseSFColorRGBAValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFColorRGBAInvalid, ex);
			}

			return null;
		}

		internal List<double> ParseSFFloatOrMFFloatValue()
		{
			// sffloatValue | [ ] | [ sffloatValues ]

			try
			{
				object token=PeekNextToken();

				List<double> ret=new List<double>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(GetFloatNumber(GetNextNumberToken()));
					}
				}
				else ret.Add(GetFloatNumber(GetNextNumberToken()));

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFFloatInvalid, ex);
			}

			return null;
		}

		internal List<SFImage> ParseSFImageOrMFImageValue()
		{
			// sfimageValue | [ ] | [ sfimageValues ]

			try
			{
				object token=PeekNextToken();

				List<SFImage> ret=new List<SFImage>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFImageValue());
					}
				}
				else ret.Add(ParseSFImageValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFImageInvalid, ex);
			}

			return null;
		}

		internal List<int> ParseSFInt32OrMFInt32Value()
		{
			// sfint32Value | [ ] | [ sfint32Values ]

			try
			{
				object token=PeekNextToken();

				List<int> ret=new List<int>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(GetIntNumber(GetNextNumberToken()));
					}
				}
				else ret.Add(GetIntNumber(GetNextNumberToken()));

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFInt32Invalid, ex);
			}

			return null;
		}

		internal List<SFMatrix3f> ParseSFMatrix3fOrMFMatrix3fValue()
		{
			// sfmatrix3fValue | [ ] | [ sfmatrix3fValues ]

			try
			{
				object token=PeekNextToken();

				List<SFMatrix3f> ret=new List<SFMatrix3f>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFMatrix3fValue());
					}
				}
				else ret.Add(ParseSFMatrix3fValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFMatrix3fInvalid, ex);
			}

			return null;
		}

		internal List<SFMatrix4f> ParseSFMatrix4fOrMFMatrix4fValue()
		{
			// sfmatrix4fValue | [ ] | [ sfmatrix4fValues ]

			try
			{
				object token=PeekNextToken();

				List<SFMatrix4f> ret=new List<SFMatrix4f>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFMatrix4fValue());
					}
				}
				else ret.Add(ParseSFMatrix4fValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFMatrix4fInvalid, ex);
			}

			return null;
		}

		internal List<X3DNode> ParseSFNodeOrMFNodeValue()
		{
			// nodeStatement | [ ] | [ nodeStatements ]

			try
			{
				object token=PeekNextToken();

				List<X3DNode> ret=new List<X3DNode>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						X3DNode node=ParseNodeStatement();
						if(node!=null) ret.Add(node);
					}
				}
				else
				{
					VRMLTokenIdKeywordOrFieldType nullToken=token as VRMLTokenIdKeywordOrFieldType;
					if(nullToken!=null&&nullToken.id=="NULL")
					{
						GetNextIDToken(); // consume NULL
						ErrorParsing(VRMLReaderError.ImproperInitializationOfMFNode);
					}
					else
					{
						X3DNode node=ParseNodeStatement();
						if(node!=null) ret.Add(node);
					}
				}

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFNodeInvalid, ex);
			}

			return null;
		}

		internal List<SFRotation> ParseSFRotationOrMFRotationValue()
		{
			// sfrotationValue | [ ] | [ sfrotationValues ]

			try
			{
				object token=PeekNextToken();

				List<SFRotation> ret=new List<SFRotation>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFRotationValue());
					}
				}
				else ret.Add(ParseSFRotationValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFRotationInvalid, ex);
			}

			return null;
		}

		internal List<string> ParseSFStringOrMFStringValue()
		{
			// sfstringValue | [ ] | [ sfstringValues ]

			try
			{
				object token=PeekNextToken();

				List<string> ret=new List<string>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseStringValue());
					}
				}
				else ret.Add(ParseStringValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFStringInvalid, ex);
			}

			return null;
		}

		internal List<SFTime> ParseSFTimeOrMFTimeValue()
		{
			// sftimeValue | [ ] | [ sftimeValues ]

			try
			{
				object token=PeekNextToken();

				List<SFTime> ret=new List<SFTime>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFTimeValue());
					}
				}
				else ret.Add(ParseSFTimeValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFTimeInvalid, ex);
			}

			return null;
		}

		internal List<SFVec2f> ParseSFVec2fOrMFVec2fValue()
		{
			// sfvec2fValue | [ ] | [ sfvec2fValues ]

			try
			{
				object token=PeekNextToken();

				List<SFVec2f> ret=new List<SFVec2f>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFVec2fValue());
					}
				}
				else ret.Add(ParseSFVec2fValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFVec2fInvalid, ex);
			}

			return null;
		}

		internal List<SFVec3f> ParseSFVec3fOrMFVec3fValue()
		{
			// sfvec3fValue | [ ] | [ sfvec3fValues ]

			try
			{
				object token=PeekNextToken();

				List<SFVec3f> ret=new List<SFVec3f>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFVec3fValue());
					}
				}
				else ret.Add(ParseSFVec3fValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFVec3fInvalid, ex);
			}

			return null;
		}

		internal List<SFVec4f> ParseSFVec4fOrMFVec4fValue()
		{
			// sfvec4fValue | [ ] | [ sfvec4fValues ]

			try
			{
				object token=PeekNextToken();

				List<SFVec4f> ret=new List<SFVec4f>();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='[')
				{
					char ts=GetNextTerminalSymbolToken();

					for(; ; )
					{
						token=PeekNextToken();
						tsToken=token as VRMLTokenTerminalSymbol;
						if(tsToken!=null&&tsToken.symbol==']')
						{
							ts=GetNextTerminalSymbolToken();
							break;
						}

						ret.Add(ParseSFVec4fValue());
					}
				}
				else ret.Add(ParseSFVec4fValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFVec4fInvalid, ex);
			}

			return null;
		}
		#endregion

		#region Parse SF-Fields
		internal SFBool ParseSFBoolValue()
		{
			// TRUE | FALSE
			return new SFBool(ParseBoolValue());
		}

		internal SFColor ParseSFColorValue()
		{
			// float float float

			try
			{
				SFColor ret=new SFColor();
				ret.Red=ParseDoubleValue();
				ret.Green=ParseDoubleValue();
				ret.Blue=ParseDoubleValue();
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFColorInvalid, ex);
			}

			return null;
		}

		internal SFColorRGBA ParseSFColorRGBAValue()
		{
			// float float float float

			try
			{
				SFColorRGBA ret=new SFColorRGBA();
				ret.Red=ParseDoubleValue();
				ret.Green=ParseDoubleValue();
				ret.Blue=ParseDoubleValue();
				ret.Alpha=ParseDoubleValue();
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFColorRGBAInvalid, ex);
			}

			return null;
		}

		internal SFFloat ParseSFFloatValue()
		{
			// float
			return new SFFloat(ParseDoubleValue());
		}

		internal SFImage ParseSFImageValue()
		{
			// int32 int32 int32 ...

			SFImage ret=null;

			try
			{
				ret=new SFImage();
				ret.Width=GetIntNumber(GetNextNumberToken());
				ret.Height=GetIntNumber(GetNextNumberToken());
				ret.NumberOfComponents=GetIntNumber(GetNextNumberToken());
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFImageInvalid, ex);
			}

			if(ret.Width<0||ret.Height<0||ret.NumberOfComponents<0||ret.NumberOfComponents>4)
				ErrorParsingField(VRMLReaderError.SFImageInvalid);

			if(ret.Width==0||ret.Height==0||ret.NumberOfComponents==0) return ret;

			try
			{
				for(int i=0; i<ret.Width*ret.Height; i++) ret.PixelValues.Add(GetIntNumber(GetNextNumberToken()));
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFImageInvalid, ex);
			}

			return ret;
		}

		internal SFInt32 ParseSFInt32Value()
		{
			// int32
			return new SFInt32(ParseIntValue());
		}

		internal SFMatrix3f ParseSFMatrix3fValue()
		{
			// 9x float

			try
			{
				SFMatrix3f ret=new SFMatrix3f();
				for(int i=0; i<9; i++) ret.Value.Add(ParseDoubleValue());
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFMatrix3fInvalid, ex);
			}

			return null;
		}

		internal SFMatrix4f ParseSFMatrix4fValue()
		{
			// 16x float

			try
			{
				SFMatrix4f ret=new SFMatrix4f();
				for(int i=0; i<16; i++) ret.Value.Add(ParseDoubleValue());
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFMatrix4fInvalid, ex);
			}

			return null;
		}

		internal X3DNode ParseSFNodeValue()
		{
			// nodeStatement | NULL

			try
			{
				object token=PeekNextToken();
				if(token==null) ErrorUnexpectedEndOfStream();

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("node statement keyword, node id or NULL", "", "sfnodeValue");

				switch(idToken.id)
				{
					case "NULL":
						string tokenNULL=GetNextIDToken();
						return null;
					default: return ParseNodeStatement();
				}
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFNodeInvalid, ex);
			}

			return null;
		}

		internal SFRotation ParseSFRotationValue()
		{
			// float float float float

			try
			{
				SFRotation ret=new SFRotation();
				ret.X=ParseDoubleValue();
				ret.Y=ParseDoubleValue();
				ret.Z=ParseDoubleValue();
				ret.Angle=ParseDoubleValue();
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFRotationInvalid, ex);
			}

			return null;
		}

		internal SFString ParseSFStringValue()
		{
			// ".*" ... double-quotes must be \", backslashes must be \\...
			return new SFString(ParseStringValue());
		}

		internal SFTime ParseSFTimeValue()
		{
			// float

			try
			{
				return new SFTime(GetFloatNumber(ParseDoubleValue()));
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFTimeInvalid, ex);
			}

			return null;
		}

		internal SFVec2f ParseSFVec2fValue()
		{
			// float float

			try
			{
				SFVec2f ret=new SFVec2f();
				ret.X=ParseDoubleValue();
				ret.Y=ParseDoubleValue();
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFVec2fInvalid, ex);
			}

			return null;
		}

		internal SFVec3f ParseSFVec3fValue()
		{
			// float float float

			try
			{
				SFVec3f ret=new SFVec3f();
				ret.X=ParseDoubleValue();
				ret.Y=ParseDoubleValue();
				ret.Z=ParseDoubleValue();
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFVec3fInvalid, ex);
			}

			return null;
		}

		internal SFVec4f ParseSFVec4fValue()
		{
			// float float float float

			try
			{
				SFVec4f ret=new SFVec4f();
				ret.X=ParseDoubleValue();
				ret.Y=ParseDoubleValue();
				ret.Z=ParseDoubleValue();
				ret.W=ParseDoubleValue();
				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.SFVec4fInvalid, ex);
			}

			return null;
		}
		#endregion

		#region Parse MF-Fields (Wrapper on ArrayParser)
		internal MFBool ParseMFBoolValue()
		{
			// sfboolValue | [ ] | [ sfboolValues ]
			return new MFBool(ParseSFBoolOrMFBoolValue());
		}

		internal MFColor ParseMFColorValue()
		{
			// sfcolorValue | [ ] | [ sfcolorValues ]
			return new MFColor(ParseSFColorOrMFColorValue());
		}

		internal MFColorRGBA ParseMFColorRGBAValue()
		{
			// sfcolorRGBAValue | [ ] | [ sfcolorRGBAValues ]
			return new MFColorRGBA(ParseSFColorRGBAOrMFColorRGBAValue());
		}

		internal MFFloat ParseMFFloatValue()
		{
			// sffloatValue | [ ] | [ sffloatValues ]
			return new MFFloat(ParseSFFloatOrMFFloatValue());
		}

		internal MFImage ParseMFImageValue()
		{
			// sfimageValue | [ ] | [ sfimageValues ]
			return new MFImage(ParseSFImageOrMFImageValue());
		}

		internal MFInt32 ParseMFInt32Value()
		{
			// sfint32Value | [ ] | [ sfint32Values ]
			return new MFInt32(ParseSFInt32OrMFInt32Value());
		}

		internal MFMatrix3f ParseMFMatrix3fValue()
		{
			// sfmartix3fValue | [ ] | [ sfmartix3fValues ]
			return new MFMatrix3f(ParseSFMatrix3fOrMFMatrix3fValue());
		}

		internal MFMatrix4f ParseMFMatrix4fValue()
		{
			// sfmartix4fValue | [ ] | [ sfmartix4fValues ]
			return new MFMatrix4f(ParseSFMatrix4fOrMFMatrix4fValue());
		}

		internal MFNode ParseMFNodeValue()
		{
			// nodeStatement | [ ] | [ nodeStatements ]
			return new MFNode(ParseSFNodeOrMFNodeValue());
		}

		internal MFRotation ParseMFRotationValue()
		{
			// sfrotationValue | [ ] | [ sfrotationValues ]
			return new MFRotation(ParseSFRotationOrMFRotationValue());
		}

		internal MFString ParseMFStringValue()
		{
			// sfstringValue | [ ] | [ sfstringValues ]
			return new MFString(ParseSFStringOrMFStringValue());
		}

		internal MFTime ParseMFTimeValue()
		{
			// sftimeValue | [ ] | [ sftimeValues ]
			return new MFTime(ParseSFTimeOrMFTimeValue());
		}

		internal MFVec2f ParseMFVec2fValue()
		{
			// sfvec2fValue | [ ] | [ sfvec2fValues ]
			return new MFVec2f(ParseSFVec2fOrMFVec2fValue());
		}

		internal MFVec3f ParseMFVec3fValue()
		{
			// sfvec3fValue | [ ] | [ sfvec3fValues ]
			return new MFVec3f(ParseSFVec3fOrMFVec3fValue());
		}

		internal MFVec4f ParseMFVec4fValue()
		{
			// sfvec4fValue | [ ] | [ sfvec4fValues ]
			return new MFVec4f(ParseSFVec4fOrMFVec4fValue());
		}
		#endregion

		internal X3DFieldBase ParseFieldByType(FieldType fieldType)
		{
			switch(fieldType)
			{
				case FieldType.MFBool: return ParseMFBoolValue();
				case FieldType.MFColor: return ParseMFColorValue();
				case FieldType.MFColorRGBA: return ParseMFColorRGBAValue();
				case FieldType.MFFloat: return ParseMFFloatValue();
				case FieldType.MFImage: return ParseMFImageValue();
				case FieldType.MFInt32: return ParseMFInt32Value();
				case FieldType.MFMatrix3f: return ParseMFMatrix3fValue();
				case FieldType.MFMatrix4f: return ParseMFMatrix4fValue();
				case FieldType.MFNode: return ParseMFNodeValue();
				case FieldType.MFRotation: return ParseMFRotationValue();
				case FieldType.MFString: return ParseMFStringValue();
				case FieldType.MFTime: return ParseMFTimeValue();
				case FieldType.MFVec2f: return ParseMFVec2fValue();
				case FieldType.MFVec3f: return ParseMFVec3fValue();
				case FieldType.MFVec4f: return ParseMFVec4fValue();
				case FieldType.SFBool: return ParseSFBoolValue();
				case FieldType.SFColor: return ParseSFColorValue();
				case FieldType.SFColorRGBA: return ParseSFColorRGBAValue();
				case FieldType.SFFloat: return ParseSFFloatValue();
				case FieldType.SFImage: return ParseSFImageValue();
				case FieldType.SFInt32: return ParseSFInt32Value();
				case FieldType.SFMatrix3f: return ParseSFMatrix3fValue();
				case FieldType.SFMatrix4f: return ParseSFMatrix4fValue();
				case FieldType.SFNode: return ParseSFNodeValue();
				case FieldType.SFRotation: return ParseSFRotationValue();
				case FieldType.SFString: return ParseSFStringValue();
				case FieldType.SFTime: return ParseSFTimeValue();
				case FieldType.SFVec2f: return ParseSFVec2fValue();
				case FieldType.SFVec3f: return ParseSFVec3fValue();
				case FieldType.SFVec4f: return ParseSFVec4fValue();
			}

			return null;
		}
	}
}
