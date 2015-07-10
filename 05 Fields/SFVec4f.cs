namespace Free.FileFormats.VRML.Fields
{
	public class SFVec4f : X3DField
	{
		public double X=0, Y=0, Z=0, W=0;

		public SFVec4f() { }
		public SFVec4f(double x, double y, double z, double w) { X=x; Y=y; Z=z; W=w; }
	}
}
