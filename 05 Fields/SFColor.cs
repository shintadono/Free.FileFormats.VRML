namespace Free.FileFormats.VRML.Fields
{
	public class SFColor : X3DField
	{
		public double Red=0, Green=0, Blue=0;

		public SFColor() { }
		public SFColor(double red, double green, double blue) { Red=red; Green=green; Blue=blue; }
	}
}
