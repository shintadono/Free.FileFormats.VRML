using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureTransform : X3DNode, X3DTextureTransformNode
	{
		public SFVec2f Center { get; set; }
		public double Rotation { get; set; }
		public SFVec2f Scale { get; set; }
		public SFVec2f Translation { get; set; }

		public x3dTextureTransform()
		{
			Center=new SFVec2f(0, 0);
			Rotation=0;
			Scale=new SFVec2f(1, 1);
			Translation=new SFVec2f(0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureTransformPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="center") Center=parser.ParseSFVec2fValue();
			else if(id=="rotation") Rotation=parser.ParseDoubleValue();
			else if(id=="scale") Scale=parser.ParseSFVec2fValue();
			else if(id=="translation") Translation=parser.ParseSFVec2fValue();
			else return false;
			return true;
		}
	}
}
