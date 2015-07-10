using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dShaderPart : X3DNode, X3DUrlObject, IX3DShaderPartNode
	{
		public List<string> URL { get; set; }
		public string Type { get; set; }

		public x3dShaderPart()
		{
			URL=new List<string>();
			Type="VERTEX";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dShaderPartPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="url") URL=parser.ParseSFStringOrMFStringValue();
			else if(id=="type") Type=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
