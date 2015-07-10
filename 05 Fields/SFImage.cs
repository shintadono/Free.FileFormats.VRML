using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class SFImage : X3DField
	{
		public int Width=0, Height=0, NumberOfComponents=0;
		public List<int> PixelValues=new List<int>();
	}
}
