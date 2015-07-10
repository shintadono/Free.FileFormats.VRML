using System.Collections.Generic;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// The X3DNurbsSurfaceGeometryNode represents the abstract geometry type
	/// for all types of NURBS surfaces.
	/// </summary>
	public interface X3DNurbsSurfaceGeometryNode : X3DParametricGeometryNode
	{
		X3DCoordinateNode ControlPoint { get; set; }
		IX3DNurbsSurfaceGeometryNodeTexCoord TexCoord { get; set; }
		int UTessellation { get; set; }
		int VTessellation { get; set; }
		List<double> Weight { get; set; }
		bool Solid { get; set; }
		bool UClosed { get; set; }
		int UDimension { get; set; }
		List<double> UKnot { get; set; }
		int UOrder { get; set; }
		bool VClosed { get; set; }
		int VDimension { get; set; }
		List<double> VKnot { get; set; }
		int VOrder { get; set; }
	}
}
