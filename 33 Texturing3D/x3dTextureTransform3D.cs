using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureTransform3D : X3DNode, X3DTextureTransformNode
	{
		public SFVec3f Center { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFVec3f Translation { get; set; }

		public x3dTextureTransform3D()
		{
			Center=new SFVec3f(0, 0, 0);
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			Translation=new SFVec3f(0, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureTransform3DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
