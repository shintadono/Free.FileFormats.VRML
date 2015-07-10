using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node defines a set of RGBA colours to be used in the fields of another node.
	/// </summary>
	public class x3dColorRGBA : X3DNode, X3DColorNode
	{
		public List<SFColorRGBA> Color { get; set; }

		public x3dColorRGBA()
		{
			Color=new List<SFColorRGBA>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dColorRGBAPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="color") Color.AddRange(parser.ParseSFColorRGBAOrMFColorRGBAValue());
			else return false;
			return true;
		}
	}
}
