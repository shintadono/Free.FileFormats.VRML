using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ContourPolyline2D node defines a piecewise linear curve segment
	/// as a part of a trimming contour in the u,v domain of a surface.
	/// </summary>
	public class x3dContourPolyline2D : X3DNode, X3DNurbsControlCurveNode, IX3DContour2DChildren
	{
		public List<SFVec2f> ControlPoint { get; set; }

		public x3dContourPolyline2D()
		{
			ControlPoint=new List<SFVec2f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dContourPolyline2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="controlPoint") ControlPoint.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else return false;
			return true;
		}
	}
}
