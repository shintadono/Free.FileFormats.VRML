using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The TriangleSet2D node specifies a set of triangles in the local 2D coordinate system.
	/// </summary>
	public class x3dTriangleSet2D : X3DNode, X3DGeometryNode
	{
		public List<SFVec2f> Vertices { get; set; }
		public bool Solid { get; set; }

		public x3dTriangleSet2D()
		{
			Vertices=new List<SFVec2f>();
			Solid=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTriangleSet2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="vertices")Vertices.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
