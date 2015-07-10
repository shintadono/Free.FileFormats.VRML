using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureCoordinate : X3DNode, X3DTextureCoordinateNode
	{
		public List<SFVec2f> Point { get; set; }

		public x3dTextureCoordinate()
		{
			Point=new List<SFVec2f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureCoordinatePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="point") Point.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else return false;
			return true;
		}
	}
}
