using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureCoordinate3D : X3DNode, X3DTextureCoordinateNode
	{
		public List<SFVec3f> Point { get; set; }

		public x3dTextureCoordinate3D()
		{
			Point=new List<SFVec3f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureCoordinate3DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="point") Point.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else return false;
			return true;
		}
	}
}
