using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFColorRGBA : X3DArrayField
	{
		public List<SFColorRGBA> Values=new List<SFColorRGBA>();

		public MFColorRGBA() { }
		public MFColorRGBA(List<SFColorRGBA> values) { Values=values; }
	}
}
