using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFNumbers : X3DArrayField
	{
		public List<object> Values=new List<object>();

		public MFNumbers() { }
		public MFNumbers(List<object> values) { Values=values; }
	}
}
