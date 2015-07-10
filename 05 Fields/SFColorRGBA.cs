namespace Free.FileFormats.VRML.Fields
{
	public class SFColorRGBA : X3DField
	{
		public double Red=0, Green=0, Blue=0, Alpha=1;

		public SFColorRGBA() { }
		public SFColorRGBA(double red, double green, double blue, double alpha) { Red=red; Green=green; Blue=blue; Alpha=alpha; }

	}
}
