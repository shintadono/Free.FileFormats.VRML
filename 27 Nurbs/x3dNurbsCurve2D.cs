using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NurbsCurve2D node defines a trimming segment that is part of
	/// a trimming contour in the u,v domain of the surface.
	/// </summary>
	public class x3dNurbsCurve2D : X3DNode, X3DNurbsControlCurveNode, IX3DContour2DChildren
	{
		public List<SFVec2f> ControlPoint { get; set; }
		public int Tessellation { get; set; }
		public List<double> Weight { get; set; }
		public bool Closed { get; set; }
		public List<double> Knot { get; set; }
		public int Order { get; set; }

		public x3dNurbsCurve2D()
		{
			ControlPoint=new List<SFVec2f>();
			Tessellation=0;
			Weight=new List<double>();
			Closed=false;
			Knot=new List<double>();
			Order=3;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsCurve2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="controlPoint")ControlPoint.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="tessellation") Tessellation=parser.ParseIntValue();
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="closed") Closed=parser.ParseBoolValue();
			else if(id=="knot") Knot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="order") Order=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
