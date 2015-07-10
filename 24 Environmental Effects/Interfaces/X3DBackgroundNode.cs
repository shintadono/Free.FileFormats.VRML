using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// X3DBackgroundNode is the abstract type from which all backgrounds inherit.
	/// </summary>
	public interface X3DBackgroundNode : X3DBindableNode
	{
		List<double> GroundAngle { get; set; }
		List<SFColor> GroundColor { get; set; }
		List<double> SkyAngle { get; set; }
		List<SFColor> SkyColor { get; set; }
		double Transparency { get; set; }
	}
}
