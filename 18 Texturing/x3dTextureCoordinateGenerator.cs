using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureCoordinateGenerator : X3DNode, X3DTextureCoordinateNode
	{
		public string Mode { get; set; }
		public List<double> Parameter { get; set; }

		public x3dTextureCoordinateGenerator()
		{
			Mode="SPHERE";
			Parameter=new List<double>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureCoordinateGeneratorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="mode") Mode=parser.ParseStringValue();
			else if(id=="Parameter") Parameter=parser.ParseSFFloatOrMFFloatValue();
			else return false;
			return true;
		}
	}
}
