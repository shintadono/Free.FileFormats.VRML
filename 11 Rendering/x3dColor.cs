using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node defines a set of RGB colours to be used in the fields of another node.
	/// </summary>
	public class x3dColor : X3DNode, X3DColorNode
	{
		public List<SFColor> Color { get; set; }

		public x3dColor()
		{
			Color=new List<SFColor>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dColorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="color") Color.AddRange(parser.ParseSFColorOrMFColorValue());
			else return false;
			return true;
		}
	}
}
