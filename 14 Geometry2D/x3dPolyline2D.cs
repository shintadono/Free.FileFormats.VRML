using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Polyline2D node specifies a series of contiguous line segments
	/// in the local 2D coordinate system connecting the specified vertices.
	/// </summary>
	public class x3dPolyline2D : X3DNode, X3DGeometryNode
	{
		public List<SFVec2f> LineSegments { get; set; }

		public x3dPolyline2D()
		{
			LineSegments=new List<SFVec2f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPolyline2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="lineSegments") LineSegments.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else return false;
			return true;
		}
	}
}
