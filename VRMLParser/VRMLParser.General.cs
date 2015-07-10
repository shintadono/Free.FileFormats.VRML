using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Nodes;
using Free.FileFormats.VRML.RouteDeclarations;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		#region General
		void ParseX3DScene()
		{
			// headerStatement profileStatement componentStatements metaStatements statements

			// Ignores Header
			// Profile is optional

			ParseProfileStatement();
			ParseComponentStatements();
			ParseMetaStatements();
			ParseStatements(false);
		}

		void ParseProfileStatement()
		{
			// PROFILE profileNameId

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("statement keyword or node id", "", "statement");

			if(idToken.id=="PROFILE")
			{
				GetNextIDToken(); // PROFILE keyword
				string profileNameId=GetNextIDToken();
			}
		}

		void ParseComponentStatements()
		{
			// componentStatement | componentStatement componentStatements | empty

			for(; ; )
			{
				object token=PeekNextToken();
				if(token==null) ErrorUnexpectedEndOfStream();

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("statement keyword or node id", "", "statement");

				switch(idToken.id)
				{
					case "COMPONENT": ParseComponentStatement(); break;
					default: return;
				}
			}
		}

		void ParseComponentStatement()
		{
			// COMPONENT componentNameId : componentSupportLevel

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("COMPONENT", "", "COMPONENT statement");

			if(idToken.id!="COMPONENT") return;

			GetNextIDToken(); // COMPONENT keyword
			string componentNameId=GetNextIDToken(true);

			GetNextColonToken(); // :

			int componentSupportLevel=GetIntNumber(GetNextNumberToken());
		}

		void ParseExportStatement()
		{
			// EXPORT nodeNameId AS exportedNodeNameId

			string tokenEXPORT=GetNextIDToken();
			if(tokenEXPORT!="EXPORT") ErrorParsingToken("EXPORT", tokenEXPORT, "EXPORT statement");

			string nodeNameId=GetNextIDToken();

			string AS=GetNextIDToken();
			if(AS!="AS") ErrorParsingToken("AS", AS, "EXPORT statement");

			string exportedNodeNameId=GetNextIDToken();
		}

		void ParseImportStatement()
		{
			// IMPORT inlineNodeNameId.exportedNodeNameId AS nodeNameId

			string tokenIMPORT=GetNextIDToken();
			if(tokenIMPORT!="IMPORT") ErrorParsingToken("IMPORT", tokenIMPORT, "IMPORT statement");

			string inlineNodeNameId=GetNextIDToken();

			char ts=GetNextPeriodToken();

			string exportedNodeNameId=GetNextIDToken();

			string AS=GetNextIDToken();
			if(AS!="AS") ErrorParsingToken("AS", AS, "IMPORT statement");

			string nodeNameId=GetNextIDToken();
		}

		void ParseMetaStatements()
		{
			// metaStatement | metaStatement metaStatements | empty

			for(; ; )
			{
				object token=PeekNextToken();
				if(token==null) ErrorUnexpectedEndOfStream();

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("statement keyword or node id", "", "statement");

				switch(idToken.id)
				{
					case "META": ParseMetaStatement(); break;
					default: return;
				}
			}
		}

		void ParseMetaStatement()
		{
			// META metakey metavalue

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("META", "", "META statement");

			if(idToken.id=="META")
			{
				GetNextIDToken(); // META keyword
				string metakey=GetNextStringToken();
				string metavalue=GetNextStringToken();
			}
		}

		void ParseStatements(bool isProto)
		{
			// statement | statement statements | empty

			for(; ; )
			{
				object token=ConsumeNextToken(false, false, true);
				if(token==null) return; // done
				ReturnToken(token);

				if(isProto)
				{
					VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
					if(tsToken!=null&&tsToken.symbol=='}') return; // done
				}

				ParseStatement();
			}
		}

		void ParseStatement()
		{
			// nodeStatement | protoStatement | exportStatement | importStatement | routeStatement

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("statement keyword or node id", "", "statement");

			switch(idToken.id)
			{
				case "PROTO":
				case "EXTERNPROTO":
					string nodeTypeId;
					int lineOfProtoStart=line;
					X3DPrototypeInstance proto=ParseProtoStatement(out nodeTypeId);
					if(protoDefinitions.ContainsKey(nodeTypeId)) ErrorParsing(VRMLReaderError.PROTOAlreadyDefined, lineOfProtoStart);
					else protoDefinitions.Add(nodeTypeId, proto);
					break;
				case "EXPORT": ParseExportStatement(); break;
				case "IMPORT": ParseImportStatement(); break;
				case "ROUTE": ParseRouteStatement(); break;
				default:
					X3DNode node=ParseNodeStatement();
					if(node!=null) nodes.Add(node);
					break;
			}
		}

		X3DNode ParseNodeStatement()
		{
			// node | DEF nodeNameId node | USE nodeNameId

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("DEF, USE or node id", "", "node statement");

			switch(idToken.id)
			{
				case "DEF":
					{
						string tokenDEF=GetNextIDToken();
						string nodeNameId=GetNextIDToken();
						X3DNode node=ParseNode(nodeNameId);
						if(node==null) ErrorUnexpectedEndOfStream();
						instances[nodeNameId]=node;
						return node;
					}
				case "USE":
					{
						string tokenUSE=GetNextIDToken();
						string nodeNameId=GetNextIDToken();
						if(instances.ContainsKey(nodeNameId)) return instances[nodeNameId];
						ErrorParsing(VRMLReaderError.USENameNotDefined);
						return null;
					}
				default: return ParseNode(null);
			}
		}

		X3DNode ParseRootNodeStatement()
		{
			// node | DEF nodeNameId node

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("DEF or node id", "", "root node statement");

			switch(idToken.id)
			{
				case "DEF":
					{
						string tokenDEF=GetNextIDToken();
						string nodeNameId=GetNextIDToken();
						X3DNode node=ParseNode(nodeNameId);
						if(node==null) ErrorUnexpectedEndOfStream();
						instances[nodeNameId]=node;
						return node;
					}
				default: return ParseNode(null);
			}
		}

		X3DPrototypeInstance ParseProtoStatement(out string nodeTypeId)
		{
			// proto | externproto

			object token=PeekNextToken();
			if(token==null) ErrorUnexpectedEndOfStream();

			VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
			if(idToken==null) ErrorParsingToken("PROTO or EXTERNPROTO", "", "proto statement");

			switch(idToken.id)
			{
				case "PROTO": return ParseProto(out nodeTypeId);
				case "EXTERNPROTO": return ParseExternProto(out nodeTypeId);
				default:
					nodeTypeId="";
					ErrorParsingToken("PROTO or EXTERNPROTO", idToken.id, "proto statement");
					return null;
			}
		}

		void ParseProtoStatements()
		{
			// protoStatement | protoStatement protoStatements | empty

			for(; ; )
			{
				object token=PeekNextToken();
				if(token==null) ErrorUnexpectedEndOfStream();

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("statement keyword or node id", "", "proto statements");

				switch(idToken.id)
				{
					case "PROTO":
					case "EXTERNPROTO":
						string nodeTypeId;
						X3DPrototypeInstance proto=ParseProtoStatement(out nodeTypeId);
						protoDefinitions.Add(nodeTypeId, proto);
						break;
					default: return;
				}
			}
		}

		X3DPrototypeInstance ParseProto(out string nodeTypeId)
		{
			// PROTO nodeTypeId [ interfaceDeclarations ] { protoBody }

			PushNameState();

			inPROTO=true;

			string tokenPROTO=GetNextIDToken();
			if(tokenPROTO!="PROTO") ErrorParsingToken("PROTO", tokenPROTO, "PROTO statement");

			nodeTypeId=GetNextIDToken();

			char ts=GetNextTerminalSymbolToken();
			if(ts!='[') ErrorParsingToken("[", ts.ToString(), "PROTO statement '"+nodeTypeId+"'");

			List<InterfaceDeclaration> interfaceDeclarations=ParseInterfaceDeclarations();

			ts=GetNextTerminalSymbolToken();
			if(ts!=']') ErrorParsingToken("]", ts.ToString(), "PROTO statement '"+nodeTypeId+"'");

			ts=GetNextTerminalSymbolToken();
			if(ts!='{') ErrorParsingToken("{", ts.ToString(), "PROTO statement '"+nodeTypeId+"'");

			ParseProtoBody();

			ts=GetNextTerminalSymbolToken();
			if(ts!='}') ErrorParsingToken("}", ts.ToString(), "PROTO statement '"+nodeTypeId+"'");

			// Proto node of the type of the first node
			X3DPrototypeInstance ret=nodes[0].GetProto();
			ret.InterfaceDeclarations=interfaceDeclarations;
			ret.ProtoNodeName=nodeTypeId;
			ret.Nodes=nodes;

			PopNameState();

			return ret;
		}

		void ParseProtoBody()
		{
			// protoStatements rootNodeStatement statements

			ParseProtoStatements();

			nodes.Add(ParseRootNodeStatement());

			ParseStatements(true);
		}

		List<InterfaceDeclaration> ParseInterfaceDeclarations()
		{
			// interfaceDeclaration | interfaceDeclaration interfaceDeclarations | empty

			List<InterfaceDeclaration> ret=new List<InterfaceDeclaration>();

			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol==']') return ret; // done

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("interface declaration keyword", "", "PROTO statement interface declarations");

				switch(idToken.id)
				{
					case "eventIn":
					case "inputOnly":
					case "eventOut":
					case "outputOnly":
					case "field":
					case "initializeOnly":
					case "exposedField":
					case "inputOutput": ret.Add(ParseInterfaceDeclaration()); break;
					default: ErrorParsingToken("interface declaration keyword", idToken.id, "PROTO statement interface declarations");
						return null;
				}
			}
		}

		InterfaceDeclaration ParseInterfaceDeclaration()
		{
			// inputOnly fieldType inputOnlyId |
			// outputOnly fieldType outputOnlyId |
			// initializeOnly fieldType initializeOnlyId fieldValue |
			// inputOutput fieldType fieldId fieldValue

			string type=GetNextIDToken();

			InterfaceDeclaration ret=new InterfaceDeclaration();

			switch(type)
			{
				case "eventIn":
				case "inputOnly": ret.InterfaceDeclarationType=InterfaceDeclarationType.EventIn; break;
				case "eventOut":
				case "outputOnly": ret.InterfaceDeclarationType=InterfaceDeclarationType.EventOut; break;
				case "field":
				case "initializeOnly": ret.InterfaceDeclarationType=InterfaceDeclarationType.Field; break;
				case "exposedField":
				case "inputOutput": ret.InterfaceDeclarationType=InterfaceDeclarationType.ExposedField; break;
				default:
					ErrorParsingToken("interface declaration keyword", type, "PROTO statement interface declarations");
					return null;
			}

			ret.FieldType=GetNextFieldTypeToken();
			ret.FieldId=GetNextIDToken();

			if(ret.InterfaceDeclarationType==InterfaceDeclarationType.Field||ret.InterfaceDeclarationType==InterfaceDeclarationType.ExposedField)
				ret.DefaultValue=ParseFieldByType(ret.FieldType);

			return ret;
		}

		EXTERNPROTO ParseExternProto(out string nodeTypeId)
		{
			// EXTERNPROTO nodeTypeId [ externInterfaceDeclarations ] URLList

			string tokenEXTERNPROTO=GetNextIDToken();
			if(tokenEXTERNPROTO!="EXTERNPROTO") ErrorParsingToken("EXTERNPROTO", tokenEXTERNPROTO, "EXTERNPROTO statement");

			nodeTypeId=GetNextIDToken();

			char ts=GetNextTerminalSymbolToken();
			if(ts!='[') ErrorParsingToken("[", ts.ToString(), "EXTERNPROTO statement");

			List<InterfaceDeclaration> interfaceDeclarations=ParseExternInterfaceDeclarations();

			ts=GetNextTerminalSymbolToken();
			if(ts!=']') ErrorParsingToken("]", ts.ToString(), "EXTERNPROTO statement");

			EXTERNPROTO ret=new EXTERNPROTO();
			ret.InterfaceDeclarations=interfaceDeclarations;
			ret.ProtoNodeName=nodeTypeId;
			ret.URLList=ParseSFStringOrMFStringValue();
			return ret;
		}

		List<InterfaceDeclaration> ParseExternInterfaceDeclarations()
		{
			// externInterfaceDeclaration | externInterfaceDeclaration externInterfaceDeclarations | empty

			List<InterfaceDeclaration> ret=new List<InterfaceDeclaration>();

			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol==']') return ret; // done

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("interface declaration keyword", "", "EXTRENPROTO statement interface declarations");

				switch(idToken.id)
				{
					case "eventIn":
					case "inputOnly":
					case "eventOut":
					case "outputOnly":
					case "field":
					case "initializeOnly":
					case "exposedField":
					case "inputOutput": ret.Add(ParseExternInterfaceDeclaration()); break;
					default:
						ErrorParsingToken("interface declaration keyword", idToken.id, "EXTRENPROTO statement interface declarations");
						return null;
				}
			}
		}

		InterfaceDeclaration ParseExternInterfaceDeclaration()
		{
			// inputOnly fieldType inputOnlyId | outputOnly fieldType outputOnlyId |
			// initializeOnly fieldType initializeOnlyId | inputOutput fieldType inputOutputFieldId

			InterfaceDeclaration ret=new InterfaceDeclaration();

			string type=GetNextIDToken();

			switch(type)
			{
				case "eventIn":
				case "inputOnly": ret.InterfaceDeclarationType=InterfaceDeclarationType.EventIn; break;
				case "eventOut":
				case "outputOnly": ret.InterfaceDeclarationType=InterfaceDeclarationType.EventOut; break;
				case "field":
				case "initializeOnly": ret.InterfaceDeclarationType=InterfaceDeclarationType.Field; break;
				case "exposedField":
				case "inputOutput": ret.InterfaceDeclarationType=InterfaceDeclarationType.ExposedField; break;
				default:
					ErrorParsingToken("interface declaration keyword", type, "EXTERNPROTO statement interface declarations");
					return null;
			}

			ret.FieldType=GetNextFieldTypeToken();
			ret.FieldId=GetNextIDToken();

			return ret;
		}

		void ParseRouteStatement()
		{
			// ROUTE nodeNameId . eventOutId TO nodeNameId . eventInId

			string tokenROUTE=GetNextIDToken();
			if(tokenROUTE!="ROUTE") ErrorParsingToken("ROUTE", tokenROUTE, "ROUTE statement");

			string nodeNameIdOut=GetNextIDToken();

			char ts=GetNextPeriodToken();

			string eventOutId=GetNextIDToken();

			string TO=GetNextIDToken();
			if(TO!="TO") ErrorParsingToken("TO", TO, "ROUTE statement");

			string nodeNameIdIn=GetNextIDToken();

			ts=GetNextPeriodToken();

			string eventInId=GetNextIDToken();

			bool wasWarning=false;
			if(!instances.ContainsKey(nodeNameIdOut))
			{
				ErrorParsing(VRMLReaderError.RouteSourceNameNotDefined);
				wasWarning=true;
			}
			if(!instances.ContainsKey(nodeNameIdIn))
			{
				ErrorParsing(VRMLReaderError.RouteTargetNameNotDefined);
				wasWarning=true;
			}

			if(!wasWarning)
			{
				RouteDeclaration route=new RouteDeclaration();
				route.EventOut=eventOutId;
				route.Target=instances[nodeNameIdIn];
				route.EventOut=eventInId;
				instances[nodeNameIdOut].Routes.Add(route);
			}
		}
		#endregion
	}
}
