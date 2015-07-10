using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFFloat : X3DArrayField
	{
		public List<double> Values=new List<double>();

		public MFFloat() { }
		public MFFloat(List<double> values) { Values=values; }
	}
}
