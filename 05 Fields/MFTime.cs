using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFTime : X3DArrayField
	{
		public List<SFTime> Values=new List<SFTime>();

		public MFTime() { }
		public MFTime(List<SFTime> values) { Values=values; }
	}
}
