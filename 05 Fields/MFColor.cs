using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFColor : X3DArrayField
	{
		public List<SFColor> Values=new List<SFColor>();

		public MFColor() { }
		public MFColor(List<SFColor> values) { Values=values; }
	}
}
