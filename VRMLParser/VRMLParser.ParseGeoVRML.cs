using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		SFVec3f CoordString2SFVec3f(string coordsstring)
		{
			string[] parts=coordsstring.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			if(parts.Length!=3) ErrorParsingField(VRMLReaderError.SFStringInvalid);

			try
			{
				double x=double.Parse(parts[0], VRMLParser.nc);
				double y=double.Parse(parts[1], VRMLParser.nc);
				double z=double.Parse(parts[2], VRMLParser.nc);
				return new SFVec3f(x, y, z);
			}
			catch(UserCancellationException) { throw; }
			catch
			{
				ErrorParsingField(VRMLReaderError.SFStringInvalid);
			}

			return null;
		}

		double String2Double(string doublestring)
		{
			try
			{
				return double.Parse(doublestring, VRMLParser.nc);
			}
			catch(UserCancellationException) { throw; }
			catch
			{
				ErrorParsingField(VRMLReaderError.SFStringInvalid);
			}

			return 0;
		}

		internal SFVec3f ParseSFVec3fStringValue()
		{
			object token=PeekNextToken();
			if(token is VRMLTokenString) return CoordString2SFVec3f(ParseStringValue());
			return ParseSFVec3fValue();
		}

		internal List<SFVec3f> ParseSFVec3fStringsValue()
		{
			List<SFVec3f> ret=new List<SFVec3f>();

			object token=PeekNextToken();
			if(token is VRMLTokenString)
			{
				string coordsstring=ParseStringValue();

				string[] parts=coordsstring.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
				if(parts.Length%3!=0) ErrorParsingField(VRMLReaderError.SFStringInvalid);

				try
				{
					double x=0, y=0, z=0;

					for(int i=0; i<parts.Length; i++)
					{
						int a=i%3;
						if(a==0) x=double.Parse(parts[i], VRMLParser.nc);
						if(a==1) y=double.Parse(parts[i], VRMLParser.nc);
						if(a==2) z=double.Parse(parts[i], VRMLParser.nc);
						if(a==2) ret.Add(new SFVec3f(x, y, z));
					}
				}
				catch(UserCancellationException) { throw; }
				catch
				{
					ErrorParsingField(VRMLReaderError.SFStringInvalid);
				}

			}
			else ret.Add(ParseSFVec3fValue());
			return ret;
		}

		internal double ParseDoubleStringValue()
		{
			object token=PeekNextToken();
			if(token is VRMLTokenString) return String2Double(ParseStringValue());
			return ParseDoubleValue();
		}

		internal List<SFVec3f> ParseSFVec3fStringOrMFVec3fStringsValue()
		{
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

						ret.Add(ParseSFVec3fStringValue());
					}
				}
				else ret.Add(ParseSFVec3fStringValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFVec3fInvalid, ex);
			}
			return null;
		}

		internal List<SFVec3f> ParseGeoCoordinatePointValue()
		{
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

						ret.AddRange(ParseSFVec3fStringsValue());
					}
				}
				else ret.AddRange(ParseSFVec3fStringsValue());

				return ret;
			}
			catch(UserCancellationException) { throw; }
			catch(Exception ex)
			{
				ErrorParsingField(VRMLReaderError.MFVec3fInvalid, ex);
			}

			return null;
		}
	}
}
