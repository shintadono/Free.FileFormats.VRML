using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMatrix4VertexAttribute : X3DNode, X3DVertexAttributeNode
	{
		public List<SFMatrix4f> Value { get; set; }
		public string Name { get; set; }

		public x3dMatrix4VertexAttribute()
		{
			Value=new List<SFMatrix4f>();
			Name="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMatrix4VertexAttributePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="value") Value.AddRange(parser.ParseSFMatrix4fOrMFMatrix4fValue());
			else if(id=="name") Name=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
