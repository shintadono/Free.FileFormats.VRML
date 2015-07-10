using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFRotation : X3DArrayField
	{
		public List<SFRotation> Values=new List<SFRotation>();

		public MFRotation() { }
		public MFRotation(List<SFRotation> values) { Values=values; }
	}
}
