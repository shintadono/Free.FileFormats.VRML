using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class SFMatrix3f : X3DField
	{
		public List<double> Value=new List<double>();

		public SFMatrix3f() { }
		public SFMatrix3f(List<double> value) { Value=value; }
	}
}
