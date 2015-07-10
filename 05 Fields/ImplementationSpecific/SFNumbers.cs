using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class SFNumbers : X3DField
	{
		public List<object> Values=new List<object>();

		public SFNumbers() { }
		public SFNumbers(List<object> values) { Values=values; }
	}
}
