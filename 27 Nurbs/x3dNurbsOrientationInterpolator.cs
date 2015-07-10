using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// NurbsOrientationInterpolator specifies a 3D NURBS curve using the
	/// same fields as described for the NurbsCurve node.
	/// </summary>
	public class x3dNurbsOrientationInterpolator : X3DNode, X3DChildNode
	{
		public X3DCoordinateNode ControlPoint { get; set; }
		public List<double> Knot { get; set; }
		public int Order { get; set; }
		public List<double> Weight { get; set; }

		public x3dNurbsOrientationInterpolator()
		{
			Weight=new List<double>();
			Knot=new List<double>();
			Order=3;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsOrientationInterpolatorPROTO(); }

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
			else if(id=="knot") Knot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="order") Order=parser.ParseIntValue();
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else return false;
			return true;
		}
	}
}
