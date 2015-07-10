using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFString : X3DArrayField
	{
		public List<string> Values=new List<string>();

		public MFString() { }
		public MFString(List<string> values) { Values=values; }
	}
}
