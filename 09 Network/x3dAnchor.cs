using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Anchor grouping node retrieves the content of a URL when the user
	/// activates (e.g., clicks) some geometry contained within the Anchor node's children.
	/// </summary>
	public class x3dAnchor : X3DNode, X3DGroupingNode
	{
		public List<X3DChildNode> Children { get; set; }
		public string Description { get; set; }
		public List<string> Parameter { get; set; }
		public List<string> URL { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dAnchor()
		{
			Children=new List<X3DChildNode>();
			Description="";
			Parameter=new List<string>();
			URL=new List<string>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dAnchorPROTO(); }

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
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="parameter") Parameter.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
