using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFMatrix3f : X3DArrayField
	{
		public List<SFMatrix3f> Values=new List<SFMatrix3f>();

		public MFMatrix3f() { }
		public MFMatrix3f(List<SFMatrix3f> values) { Values=values; }
	}
}
