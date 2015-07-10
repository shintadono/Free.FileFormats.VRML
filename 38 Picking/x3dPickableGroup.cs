using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPickableGroup : X3DNode, X3DGroupingNode, X3DPickableObject
	{
		public List<X3DChildNode> Children { get; set; }
		public List<string> ObjectType { get; set; }
		public bool Pickable { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		bool wasObjectType=false;

		public x3dPickableGroup()
		{
			Children=new List<X3DChildNode>();
			ObjectType=new List<string>();
			ObjectType.Add("ALL");
			Pickable=true;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPickableGroupPROTO(); }

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
			else if(id=="objectType")
			{
				if(wasObjectType) ObjectType.AddRange(parser.ParseSFStringOrMFStringValue());
				else ObjectType=parser.ParseSFStringOrMFStringValue();
				wasObjectType=true;
			}
			else if(id=="pickable") Pickable=parser.ParseBoolValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
