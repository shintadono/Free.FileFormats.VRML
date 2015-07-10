using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dBoundedPhysicsModel : X3DNode, X3DParticlePhysicsModelNode
	{
		public bool Enabled { get; set; }
		public X3DGeometryNode Geometry { get; set; }

		public x3dBoundedPhysicsModel()
		{
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBoundedPhysicsModelPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="geometry")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Geometry=node as X3DGeometryNode;
					if(Geometry==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
