using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// NurbsSweptSurface describes a generalized surface that defines a path
	/// in 2D space and constant cross section that may be 2D or 3D of the path.
	/// </summary>
	public class x3dNurbsSweptSurface : X3DNode, X3DParametricGeometryNode
	{
		public X3DNurbsControlCurveNode CrossSectionCurve { get; set; }
		public IX3DNurbsCurveNode TrajectoryCurve { get; set; }
		public bool CCW { get; set; }
		public bool Solid { get; set; }

		public x3dNurbsSweptSurface()
		{
			CCW=true;
			Solid=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsSweptSurfacePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="crossSectionCurve")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					CrossSectionCurve=node as X3DNurbsControlCurveNode;
					if(CrossSectionCurve==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="trajectoryCurve")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TrajectoryCurve=node as IX3DNurbsCurveNode;
					if(TrajectoryCurve==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="ccw") CCW=parser.ParseBoolValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
