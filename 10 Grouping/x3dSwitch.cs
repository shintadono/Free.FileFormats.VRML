using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Switch grouping node traverses zero or one of the nodes specified in the children field.
	/// </summary>
	public class x3dSwitch : X3DNode, X3DGroupingNode
	{
		public List<X3DChildNode> Children { get; set; }
		public int WhichChoice { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public List<X3DChildNode> Choice { get { return Children; } set { Children=value; } }

		public x3dSwitch()
		{
			Children=new List<X3DChildNode>();
			WhichChoice=-1;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSwitchPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="choice"||id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode choice=node as X3DChildNode;
					if(choice==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Choice.Add(choice);
				}
			}
			else if(id=="whichChoice") WhichChoice=parser.ParseIntValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
