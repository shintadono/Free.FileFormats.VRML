using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Nodes;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		List<object> ParseUntypedFieldValueNumbers()
		{
			List<object> ret=new List<object>();

			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenNumber n=token as VRMLTokenNumber;
				if(n==null) return ret;

				ret.Add(n.number);

				ConsumeNextToken(false, false, false);
			}
		}

		X3DFieldBase ParseUntypedFieldValueArray()
		{
			char ts=GetNextTerminalSymbolToken(); // [

			object token=PeekNextToken();

			X3DFieldBase ret=null;

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken!=null) ret=new MFNode(ParseUntypedFieldValueNodeArray());

			VRMLTokenString strToken=token as VRMLTokenString;
			if(strToken!=null) ret=new MFString(ParseUntypedFieldValueStringArray());

			VRMLTokenNumber numberToken=token as VRMLTokenNumber;
			if(numberToken!=null) ret=new MFNumbers(ParseUntypedFieldValueNumbers());

			ts=GetNextTerminalSymbolToken();
			if(ts!=']') ErrorParsingToken("]", ts.ToString(), "unknown type value (array)");

			if(ret==null) ret=new MFEmpty();
			return ret;
		}

		List<X3DNode> ParseUntypedFieldValueNodeArray()
		{
			List<X3DNode> ret=new List<X3DNode>();
			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol==']') return ret; // done

				X3DNode node=ParseNodeStatement();
				if(node!=null) ret.Add(node);
			}
		}

		List<string> ParseUntypedFieldValueStringArray()
		{
			List<string> ret=new List<string>();

			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol==']') return ret; // done

				ret.Add(GetNextStringToken());
			}
		}
		
		internal X3DFieldBase ParseUntypedFieldValue()
		{
			object token=PeekNextToken();

			#region sfboolValue or sfnodeValue (NULL or Node(s))
			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;

			if(idToken!=null)
			{
				switch(idToken.id)
				{
					case "TRUE": GetNextIDToken(); return new SFBool(true);
					case "FALSE": GetNextIDToken(); return new SFBool(false);
					case "NULL": GetNextIDToken(); return null;
					default: return ParseNodeStatement();
				}
			}
			#endregion

			#region mf*Values ([-Token)
			VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
			if(tsToken!=null)
			{
				if(tsToken.symbol!='[') ErrorParsingToken("[", tsToken.symbol.ToString(), "unknown type value");
				return ParseUntypedFieldValueArray();
			}
			#endregion

			#region sfstringValue
			VRMLTokenString strToken=token as VRMLTokenString;
			if(strToken!=null) return new SFString(GetNextStringToken());
			#endregion

			#region sfcolorValue, sffloatValue, sfimageValue, sfint32Value, sfrotationValue, sftimeValue, sfvec2fValue or sfvec3fValue
			VRMLTokenNumber numberToken=token as VRMLTokenNumber;
			if(numberToken!=null) return new SFNumbers(ParseUntypedFieldValueNumbers());
			#endregion

			return null;
		}
	}
}
