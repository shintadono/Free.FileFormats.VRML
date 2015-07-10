using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCollisionSensor : X3DNode, X3DSensorNode
	{
		public IX3DCollisionCollectionNode Collider { get; set; }
		public bool Enabled { get; set; }

		public x3dCollisionSensor()
		{
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCollisionSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="collidables"||id=="collider")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Collider=node as IX3DCollisionCollectionNode;
					if(Collider==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
