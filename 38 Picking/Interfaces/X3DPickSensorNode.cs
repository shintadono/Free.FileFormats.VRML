using System.Collections.Generic;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DPickSensorNode : X3DSensorNode
	{
		List<string> ObjectType { get; set; }
		X3DGeometryNode PickingGeometry { get; set; }
		List<IX3DPickSensorNodePickTarget> PickTarget { get; set; }
		string IntersectionType { get; set; }
		string SortOrder { get; set; }
	}
}
