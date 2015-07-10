using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFVec2f : X3DArrayField
	{
		public List<SFVec2f> Values=new List<SFVec2f>();
		
		public MFVec2f() { }
		public MFVec2f(List<SFVec2f> values) { Values=values; }
	}
}
