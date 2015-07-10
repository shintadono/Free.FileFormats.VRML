using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The WorldInfo node contains information about the world. This node is
	/// strictly for documentation purposes and has no effect on the visual
	/// appearance or behaviour of the world. The title field is intended to
	/// store the name or title of the world so that browsers can present this
	/// to the user (perhaps in the window border).
	/// </summary>
	public class x3dWorldInfo : X3DNode, X3DInfoNode
	{
		public List<string> Info { get; set; }
		public string Title { get; set; }

		public x3dWorldInfo()
		{
			Info=new List<string>();
			Title="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dWorldInfoPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="info") Info.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="title") Title=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
