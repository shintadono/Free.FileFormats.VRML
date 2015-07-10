using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// NurbsPositionInterpolator describes a 3D NURBS curve using dimension,
	/// keyValue, keyWeight, knot, and order.
	/// </summary>
	public class x3dNurbsPositionInterpolator : X3DNode, X3DChildNode
	{
		public X3DCoordinateNode ControlPoint { get; set; }
		public List<double> Knot { get; set; }
		public int Order { get; set; }
		public List<double> Weight { get; set; }

		// deprecated
		public int Dimension { get; set; }
		public bool FractionAbsolute { get; set; }

		public x3dNurbsPositionInterpolator()
		{
			Weight=new List<double>();
			Knot=new List<double>();
			Order=3;

			Dimension=0;
			FractionAbsolute=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsPositionInterpolatorPROTO(); }

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
			else if(id=="weight"||id=="keyWeight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="dimension") Dimension=parser.ParseIntValue();
			else if(id=="fractionAbsolute") FractionAbsolute=parser.ParseBoolValue();
			else if(id=="keyValue")
			{
				List<SFVec3f> controlPoints=parser.ParseSFVec3fOrMFVec3fValue();
				if(ControlPoint==null) ControlPoint=new x3dCoordinate();
				
				x3dCoordinate cp=ControlPoint as x3dCoordinate;
				if(cp!=null) cp.Point.AddRange(controlPoints);
			}
			else return false;
			return true;
		}
	}
}
