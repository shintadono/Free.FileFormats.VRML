using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ViewpointGroup node is used to control display of viewpoints on the viewpoint list.
	/// </summary>
	public class x3dViewpointGroup : X3DNode, X3DChildNode, IX3DViewpointgroupChildren
	{
		public SFVec3f Center { get; set; }
		public List<IX3DViewpointgroupChildren> Children { get; set; }
		public string Description { get; set; }
		public bool Displayed { get; set; }
		public bool RetainUserOffsets { get; set; }
		public SFVec3f Size { get; set; }

		public x3dViewpointGroup()
		{
			Center=new SFVec3f(0, 0, 0);
			Children=new List<IX3DViewpointgroupChildren>();
			Description="";
			Displayed=true;
			RetainUserOffsets=false;
			Size=new SFVec3f(0, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dViewpointGroupPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DViewpointgroupChildren child=node as IX3DViewpointgroupChildren;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="displayed") Displayed=parser.ParseBoolValue();
			else if(id=="retainUserOffsets") RetainUserOffsets=parser.ParseBoolValue();
			else if(id=="size") Size=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
