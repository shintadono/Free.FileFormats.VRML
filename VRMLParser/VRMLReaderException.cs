using System;

namespace Free.FileFormats.VRML
{
	public class VRMLReaderException : Exception
	{
		public VRMLReaderError message;
		public int line;

		internal VRMLReaderException(VRMLReaderError message, int line)
			: base(VRMLReaderErrorToMessageString(message, line))
		{
			this.message=message;
			this.line=line;
		}

		internal VRMLReaderException(VRMLReaderError message, Exception reason, int line)
			: base(VRMLReaderErrorToMessageString(message, line), reason)
		{
			this.message=message;
			this.line=line;
		}

		internal static string VRMLReaderErrorToMessageString(VRMLReaderError message, int line)
		{
			switch(message)
			{
				case VRMLReaderError.UnexpectedEndOfStream: return string.Format("Error: Unexpected end of stream/file.");
				case VRMLReaderError.IllegalCharacterInStream: return string.Format("Error: Illegal character found in stream/file in line: {0}", line);
				case VRMLReaderError.PROTOAlreadyDefined: return string.Format("Error: (EXTERN)PROTO definition already defined in line: {0}", line);
				case VRMLReaderError.MultipleISStatementForField: return string.Format("Error: Multiple IS statement for field in line: {0}", line);
				case VRMLReaderError.UnexpectedNodeType: return string.Format("Error: Node of unexpected type in line: {0}", line);
				case VRMLReaderError.UnknownFieldInNode: return string.Format("Error: Unknown field node in line: {0}", line);
				case VRMLReaderError.ProtoFound: return string.Format("Error: (EXTERN)PROTO node used in line: {0}", line);

				case VRMLReaderError.SFBoolInvalid: return string.Format("Error parsing SFBool field in line: {0}", line);
				case VRMLReaderError.SFColorInvalid: return string.Format("Error parsing SFColor field in line: {0}", line);
				case VRMLReaderError.SFColorRGBAInvalid: return string.Format("Error parsing SFColorRGBA field in line: {0}", line);
				case VRMLReaderError.SFFloatInvalid: return string.Format("Error parsing SFFloat/SFDouble field in line: {0}", line);
				case VRMLReaderError.SFImageInvalid: return string.Format("Error parsing SFImage field in line: {0}", line);
				case VRMLReaderError.SFInt32Invalid: return string.Format("Error parsing SFInt32 field in line: {0}", line);
				case VRMLReaderError.SFMatrix3fInvalid: return string.Format("Error parsing SFMatrix3(f/d) field in line: {0}", line);
				case VRMLReaderError.SFMatrix4fInvalid: return string.Format("Error parsing SFMatrix4(f/d) field in line: {0}", line);
				case VRMLReaderError.SFNodeInvalid: return string.Format("Error parsing SFNode field in line: {0}", line);
				case VRMLReaderError.SFRotationInvalid: return string.Format("Error parsing SFRotation field in line: {0}", line);
				case VRMLReaderError.SFStringInvalid: return string.Format("Error parsing SFString field in line: {0}", line);
				case VRMLReaderError.SFTimeInvalid: return string.Format("Error parsing SFTime field in line: {0}", line);
				case VRMLReaderError.SFVec2fInvalid: return string.Format("Error parsing SFVec2(f/d) field in line: {0}", line);
				case VRMLReaderError.SFVec3fInvalid: return string.Format("Error parsing SFVec3(f/d) field in line: {0}", line);
				case VRMLReaderError.SFVec4fInvalid: return string.Format("Error parsing SFVec4(f/d) field in line: {0}", line);
				case VRMLReaderError.MFBoolInvalid: return string.Format("Error parsing MFBool field in line: {0}", line);
				case VRMLReaderError.MFColorInvalid: return string.Format("Error parsing MFColor field in line: {0}", line);
				case VRMLReaderError.MFColorRGBAInvalid: return string.Format("Error parsing MFColorRGBA field in line: {0}", line);
				case VRMLReaderError.MFFloatInvalid: return string.Format("Error parsing MFFloat/MFDouble field in line: {0}", line);
				case VRMLReaderError.MFImageInvalid: return string.Format("Error parsing MFImage field in line: {0}", line);
				case VRMLReaderError.MFInt32Invalid: return string.Format("Error parsing MFInt32 field in line: {0}", line);
				case VRMLReaderError.MFMatrix3fInvalid: return string.Format("Error parsing MFMatrix3(f/d) field in line: {0}", line);
				case VRMLReaderError.MFMatrix4fInvalid: return string.Format("Error parsing MFMatrix4(f/d) field in line: {0}", line);
				case VRMLReaderError.MFNodeInvalid: return string.Format("Error parsing MFNode field in line: {0}", line);
				case VRMLReaderError.MFRotationInvalid: return string.Format("Error parsing MFRotation field in line: {0}", line);
				case VRMLReaderError.MFStringInvalid: return string.Format("Error parsing MFString field in line: {0}", line);
				case VRMLReaderError.MFTimeInvalid: return string.Format("Error parsing MFTime field in line: {0}", line);
				case VRMLReaderError.MFVec2fInvalid: return string.Format("Error parsing MFVec2(f/d) field in line: {0}", line);
				case VRMLReaderError.MFVec3fInvalid: return string.Format("Error parsing MFVec3(f/d) field in line: {0}", line);
				case VRMLReaderError.MFVec4fInvalid: return string.Format("Error parsing MFVec4(f/d) field in line: {0}", line);

				case VRMLReaderError.USENameNotDefined: return string.Format("Error: Name in USE statement is not defined in line: {0}", line);
				case VRMLReaderError.RouteSourceNameNotDefined: return string.Format("Error: Source name of ROUTE statement is not defined in line: {0}", line);
				case VRMLReaderError.RouteTargetNameNotDefined: return string.Format("Error: Target name of ROUTE statement is not defined in line: {0}", line);
				case VRMLReaderError.RedundantISStatement: return string.Format("Error: Redundant IS statement for field in line: {0}", line);
				case VRMLReaderError.ImproperInitializationOfMFNode: return string.Format("Error: Improper initialization of MFNode in line: {0}", line);
			}

			return string.Format("Error: Unknown error while reading VRML stream/file in line: {0}", line);
		}
	}
}
