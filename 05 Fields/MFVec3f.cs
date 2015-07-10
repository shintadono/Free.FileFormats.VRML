using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFVec3f : X3DArrayField
	{
		public List<SFVec3f> Values=new List<SFVec3f>();

		public MFVec3f() { }
		public MFVec3f(List<SFVec3f> values) { Values=values; }
	}
}
