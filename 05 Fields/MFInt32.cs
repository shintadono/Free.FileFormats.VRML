using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFInt32 : X3DArrayField
	{
		public List<int> Values=new List<int>();

		public MFInt32() { }
		public MFInt32(List<int> values) { Values=values; }
	}
}
