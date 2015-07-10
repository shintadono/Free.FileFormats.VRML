using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCollisionSpace : X3DNode, X3DNBodyCollisionSpaceNode
	{
		public List<X3DNode> Collidables { get; set; }
		public bool Enabled { get; set; }
		public bool UseGeometry { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dCollisionSpace()
		{
			Collidables=new List<X3DNode>();
			Enabled=true;
			UseGeometry=false;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCollisionSpacePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="collidables") Collidables.AddRange(parser.ParseSFNodeOrMFNodeValue());
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="useGeometry") UseGeometry=parser.ParseBoolValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
