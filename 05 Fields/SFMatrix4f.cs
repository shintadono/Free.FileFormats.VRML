using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class SFMatrix4f : X3DField
	{
		public List<double> Value=new List<double>();

		public SFMatrix4f() { }
		public SFMatrix4f(List<double> value) { Value=value; }
	}
}
