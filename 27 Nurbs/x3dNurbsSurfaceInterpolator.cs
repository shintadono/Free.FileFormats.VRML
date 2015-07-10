using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// NurbsSurfaceInterpolator describes a 3D NURBS surface.
	/// </summary>
	public class x3dNurbsSurfaceInterpolator : X3DNode, X3DChildNode
	{
		public X3DCoordinateNode ControlPoint { get; set; }
		public List<double> Weight { get; set; }
		public int UDimension { get; set; }
		public List<double> UKnot { get; set; }
		public int UOrder { get; set; }
		public int VDimension { get; set; }
		public List<double> VKnot { get; set; }
		public int VOrder { get; set; }

		public x3dNurbsSurfaceInterpolator()
		{
			Weight=new List<double>();
			UDimension=0;
			UKnot=new List<double>();
			UOrder=3;
			VDimension=0;
			VKnot=new List<double>();
			VOrder=3;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsSurfaceInterpolatorPROTO(); }

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
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="uDimension") UDimension=parser.ParseIntValue();
			else if(id=="uKnot") UKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="uOrder") UOrder=parser.ParseIntValue();
			else if(id=="vDimension") VDimension=parser.ParseIntValue();
			else if(id=="vKnot") VKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="vOrder") VOrder=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
