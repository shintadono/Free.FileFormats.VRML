using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFMatrix4f : X3DArrayField
	{
		public List<SFMatrix4f> Values=new List<SFMatrix4f>();

		public MFMatrix4f() { }
		public MFMatrix4f(List<SFMatrix4f> values) { Values=values; }
	}
}
