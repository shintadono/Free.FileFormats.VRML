using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// NurbsSwungSurface describes a generalized surface that defines a path
	/// and constant cross section of the path.
	/// </summary>
	public class x3dNurbsSwungSurface : X3DNode, X3DParametricGeometryNode
	{
		public X3DNurbsControlCurveNode ProfileCurve { get; set; }
		public X3DNurbsControlCurveNode TrajectoryCurve { get; set; }
		public bool CCW { get; set; }
		public bool Solid { get; set; }

		public x3dNurbsSwungSurface()
		{
			CCW=true;
			Solid=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsSwungSurfacePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="profileCurve")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					ProfileCurve=node as X3DNurbsControlCurveNode;
					if(ProfileCurve==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="trajectoryCurve")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TrajectoryCurve=node as X3DNurbsControlCurveNode;
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
