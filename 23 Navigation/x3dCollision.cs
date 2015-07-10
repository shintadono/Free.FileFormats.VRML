using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Collision node is a grouping node that specifies the collision
	/// detection properties for its children (and their descendants).
	/// </summary>
	public class x3dCollision : X3DNode, X3DGroupingNode, X3DSensorNode
	{
		public List<X3DChildNode> Children { get; set; }
		public bool Enabled { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public X3DChildNode Proxy { get; set; }

		public bool Collide { get { return Enabled; } set { Enabled=value; } }

		public x3dCollision()
		{
			Children=new List<X3DChildNode>();
			Collide=true;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCollisionPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="collide"||id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else if(id=="proxy")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Proxy=node as X3DChildNode;
					if(Proxy==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
