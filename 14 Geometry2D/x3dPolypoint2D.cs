using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Polyline2D node specifies a set of vertices in the local 2D
	/// coordinate system at each of which is displayed a point.
	/// </summary>
	public class x3dPolypoint2D : X3DNode, X3DGeometryNode
	{
		public List<SFVec2f> Point { get; set; }

		public x3dPolypoint2D()
		{
			Point=new List<SFVec2f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPolypoint2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="point") Point.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else return false;
			return true;
		}
	}
}