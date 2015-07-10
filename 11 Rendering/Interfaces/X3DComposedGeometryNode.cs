using System.Collections.Generic;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This is the base node type for all composed 3D geometry in X3D.
	/// </summary>
	public interface X3DComposedGeometryNode : X3DGeometryNode
	{
		List<X3DVertexAttributeNode> Attrib { get; set; }
		X3DColorNode Color { get; set; }
		X3DCoordinateNode Coord { get; set; }
		IX3DFogCoordinateNode FogCoord { get; set; }
		X3DNormalNode Normal { get; set; }
		X3DTextureCoordinateNode TexCoord { get; set; }
		bool CCW { get; set; }
		bool ColorPerVertex { get; set; }
		bool NormalPerVertex { get; set; }
		bool Solid { get; set; }
	}
}
