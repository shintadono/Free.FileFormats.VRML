using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dFloatVertexAttribute : X3DNode, X3DGeometryNode
	{
		public List<double> Value { get; set; }
		public string Name { get; set; }
		public int NumComponents { get; set; }

		public x3dFloatVertexAttribute()
		{
			Value=new List<double>();
			Name="";
			NumComponents=4;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dFloatVertexAttributePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="value") Value.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="name") Name=parser.ParseStringValue();
			else if(id=="numComponents") NumComponents=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
