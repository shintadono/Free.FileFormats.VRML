using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureCoordinate4D : X3DNode, X3DTextureCoordinateNode
	{
		public List<SFVec4f> Point { get; set; }

		public x3dTextureCoordinate4D()
		{
			Point=new List<SFVec4f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureCoordinate4DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="point") Point.AddRange(parser.ParseSFVec4fOrMFVec4fValue());
			else return false;
			return true;
		}
	}
}
