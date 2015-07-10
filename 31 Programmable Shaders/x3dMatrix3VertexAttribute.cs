using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMatrix3VertexAttribute : X3DNode, X3DVertexAttributeNode
	{
		public List<SFMatrix3f> Value { get; set; }
		public string Name { get; set; }

		public x3dMatrix3VertexAttribute()
		{
			Value=new List<SFMatrix3f>();
			Name="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMatrix3VertexAttributePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="value") Value.AddRange(parser.ParseSFMatrix3fOrMFMatrix3fValue());
			else if(id=="name") Name=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
