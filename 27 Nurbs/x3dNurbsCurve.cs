using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NurbsCurve node is a geometry node defining a parametric curve in 3D space.
	/// </summary>
	public class x3dNurbsCurve : X3DNode, X3DParametricGeometryNode, IX3DNurbsCurveNode
	{
		public X3DCoordinateNode ControlPoint { get; set; }
		public int Tessellation { get; set; }
		public List<double> Weight { get; set; }
		public bool Closed { get; set; }
		public List<double> Knot { get; set; }
		public int Order { get; set; }

		public x3dNurbsCurve()
		{
			Tessellation=0;
			Weight=new List<double>();
			Closed=false;
			Knot=new List<double>();
			Order=3;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsCurvePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="controlPoint")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					ControlPoint=node as X3DCoordinateNode;
					if(ControlPoint==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
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
