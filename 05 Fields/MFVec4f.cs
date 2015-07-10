using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFVec4f : X3DArrayField
	{
		public List<SFVec4f> Values=new List<SFVec4f>();

		public MFVec4f() { }
		public MFVec4f(List<SFVec4f> values) { Values=values; }
	}
}
