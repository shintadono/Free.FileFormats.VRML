namespace Free.FileFormats.VRML.Fields
{
	public class SFVec3f : X3DField
	{
		public double X=0, Y=0, Z=0;

		public SFVec3f() { }
		public SFVec3f(double x, double y, double z) { X=x; Y=y; Z=z; }
	}
}
