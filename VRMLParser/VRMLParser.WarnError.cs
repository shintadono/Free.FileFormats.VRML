using System;
using Free.FileFormats.VRML.Nodes;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		void WriteWarning(string message)
		{
			if(errorHandling.ReportErrorAndWarning!=null)
				errorHandling.ReportErrorAndWarning(message);
		}

		void ErrorUnexpectedEndOfStream()
		{
			WriteWarning(VRMLReaderException.VRMLReaderErrorToMessageString(VRMLReaderError.UnexpectedEndOfStream, line));
			throw new VRMLReaderException(VRMLReaderError.UnexpectedEndOfStream, line);
		}

		#region ErrorParsingField
		internal void ErrorParsingField(VRMLReaderError error)
		{
			ErrorParsingField(error, null);
		}

		internal void ErrorParsingField(VRMLReaderError error, Exception reason)
		{
			WriteWarning(VRMLReaderException.VRMLReaderErrorToMessageString(error, line));
			if(reason!=null) WriteWarning("Reason: "+reason.ToString());
			throw new VRMLReaderException(error, reason, line);
		}
		#endregion

		#region ErrorParsingNode
		internal void ErrorParsingNode(VRMLReaderError error, X3DNode node, string fieldName, X3DNode value, int line)
		{
			ErrorParsingNode(error, null, node, fieldName, value, line);
		}

		internal void ErrorParsingNode(VRMLReaderError error, Exception reason, X3DNode node, string fieldName, X3DNode value, int line)
		{
			if(error==VRMLReaderError.UnexpectedNodeType)
			{
				if(errorHandling.UnexpectedNodeType!=ErrorWarnIgnore.Ignore)
				{
					string msg="Error parsing node: Unexpected type while parsing node: '"+node.GetNodeName()+"' field: '"+fieldName+"'";
					if(value!=null) msg+=" found: '"+value.GetNodeName()+"'";
					msg+=" in line: "+line;
					WriteWarning(msg);
				}
				if(errorHandling.UnexpectedNodeType!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.UnknownFieldInNode)
			{
				if(errorHandling.UnknownFieldInNode!=ErrorWarnIgnore.Ignore)
				{
					string msg="Error parsing node: Unknown field while parsing node: '"+node.GetNodeName()+"' field: '"+fieldName+"' in line: "+line;
					WriteWarning(msg);
				}
				if(errorHandling.UnknownFieldInNode!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.SFImageInvalid)
			{
				string msg="Error parsing node: Could not parse SFImage value while parsing node: '"+node.GetNodeName()+"' field: '"+fieldName+"' in line: "+line;
				WriteWarning(msg);
			}
			
			throw new VRMLReaderException(error, reason, line);
		}
		#endregion

		#region ErrorParsingToken
		internal void ErrorParsingToken(string excepted)
		{
			ErrorParsingToken(excepted, null, null);
		}

		internal void ErrorParsingToken(string excepted, char found)
		{
			if(found<=0x20||found==0x7f) ErrorParsingToken(excepted, string.Format("character 0x{0:x2}", found), null);
			else ErrorParsingToken(excepted, string.Format("character '{0}'", found), null);
		}

		internal void ErrorParsingToken(string excepted, object found)
		{
			ErrorParsingToken(excepted, found, null);
		}

		internal void ErrorParsingToken(string excepted, object found, string at)
		{
			string msg="Error parsing stream,";
			if(excepted!=null&&excepted!="") msg+=" "+excepted+" excepted";
			if(found!=null)
			{
				if(found is string&&(string)found!="") msg+=" "+found+" found";
				else if(found is VRMLTokenIdKeywordOrFieldType)
					msg+=" id token '"+((VRMLTokenIdKeywordOrFieldType)found).id+"' found";
				else if(found is VRMLTokenNumber)
					msg+=" number token '"+((VRMLTokenNumber)found).number+"' found";
				else if(found is VRMLTokenString)
					msg+=" string token '"+((VRMLTokenString)found).text+"' found";
				else if(found is VRMLTokenTerminalSymbol)
					msg+=" terminal symbol token '"+((VRMLTokenTerminalSymbol)found).symbol+"' found";
				else if(found is X3DNode)
					msg+=" '"+((X3DNode)found).GetNodeName()+"' node found";
			}
			if(at!=null&&at!="") msg+=" while parsing "+at;
			msg+=" in line: "+line;
			WriteWarning(msg);

			throw new VRMLReaderException(VRMLReaderError.IllegalCharacterInStream, line);
		}
		#endregion

		#region ErrorParsing
		internal void ErrorParsing(VRMLReaderError error)
		{
			ErrorParsing(error, line);
		}

		internal void ErrorParsing(VRMLReaderError error, int line)
		{
			if(error==VRMLReaderError.RedundantISStatement)
			{
				if(errorHandling.RedundantISStatement!=ErrorWarnIgnore.Ignore)
					WriteWarning("Warning: Redundant IS statement for field in line: "+line);
				if(errorHandling.RedundantISStatement!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.ImproperInitializationOfMFNode)
			{
				if(errorHandling.ImproperInitializationOfMFNode!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: Improper initialization of MFNode in line: "+line);
				if(errorHandling.ImproperInitializationOfMFNode!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.MultipleISStatementForField)
			{
				if(errorHandling.MultipleISStatementForField!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: Multiple IS statement for field in line: "+line);
				if(errorHandling.MultipleISStatementForField!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.RouteSourceNameNotDefined)
			{
				if(errorHandling.RouteSourceNameNotDefined!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: Source name of ROUTE statement is not defined in line: "+line);
				if(errorHandling.RouteSourceNameNotDefined!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.RouteTargetNameNotDefined)
			{
				if(errorHandling.RouteTargetNameNotDefined!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: Target name of ROUTE statement is not defined in line: "+line);
				if(errorHandling.RouteTargetNameNotDefined!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.USENameNotDefined)
			{
				if(errorHandling.USENameNotDefined!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: Name in USE statement is not defined in line: "+line);
				if(errorHandling.USENameNotDefined!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.PROTOAlreadyDefined)
			{
				if(errorHandling.PROTOAlreadyDefined!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: (EXTERN)PROTO definition already defined in line: "+line);
				if(errorHandling.PROTOAlreadyDefined!=ErrorWarnIgnore.Error) return;
			}
			else if(error==VRMLReaderError.UnexpectedNodeType)
			{
				if(errorHandling.UnexpectedNodeType!=ErrorWarnIgnore.Ignore)
				WriteWarning("Warning: Node of unexpected type in line: "+line);
				if(errorHandling.UnexpectedNodeType!=ErrorWarnIgnore.Error) return;
			}

			throw new VRMLReaderException(error, line);
		}

		internal void ErrorParsing(VRMLReaderError error, string nodeTypeId)
		{
			if(error==VRMLReaderError.ProtoFound) WriteWarning("Error: (EXTERN)PROTO node used: '"+nodeTypeId+"' in line: "+line);
			else if(error==VRMLReaderError.UnexpectedNodeType) WriteWarning("Error: Node of unexpected type: '"+nodeTypeId+"' in line: "+line);

			throw new VRMLReaderException(error, line);
		}
		#endregion
	}
}
