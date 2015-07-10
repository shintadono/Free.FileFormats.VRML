using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface IX3DGeoOriginNode
	{
		SFVec3f GeoCoords { get; set; }
		List<string> GeoSystem { get; set; }
		bool RotateYUp { get; set; }
	}
}
