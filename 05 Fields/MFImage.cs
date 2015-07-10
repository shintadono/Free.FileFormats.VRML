using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFImage : X3DArrayField
	{
		public List<SFImage> Values=new List<SFImage>();

		public MFImage() { }
		public MFImage(List<SFImage> values) { Values=values; }
	}
}
