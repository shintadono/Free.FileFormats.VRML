using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureTransformMatrix3D : X3DNode, X3DTextureTransformNode
	{
		public SFMatrix4f Matrix { get; set; }

		public x3dTextureTransformMatrix3D()
		{
			Matrix=new SFMatrix4f(new List<double>(new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 }));
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureTransformMatrix3DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="matrix") Matrix=parser.ParseSFMatrix4fValue();
			else return false;
			return true;
		}
	}
}
