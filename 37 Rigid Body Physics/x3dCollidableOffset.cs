using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCollidableOffset : X3DNode, X3DNBodyCollidableNode
	{
		public bool Enabled { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Translation { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public X3DNBodyCollidableNode Collidable { get; set; }

		public x3dCollidableOffset()
		{
			Enabled=true;
			Rotation=new SFRotation(0, 0, 1, 0);
			Translation=new SFVec3f(0, 0, 0);
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCollidableOffsetPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else if(id=="collidable")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Collidable=node as X3DNBodyCollidableNode;
					if(Collidable==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
