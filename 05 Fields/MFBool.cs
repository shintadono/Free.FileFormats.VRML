using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFBool : X3DArrayField
	{
		public List<bool> Values=new List<bool>();

		public MFBool() { }
		public MFBool(List<bool> values) { Values=values; }
	}
}
