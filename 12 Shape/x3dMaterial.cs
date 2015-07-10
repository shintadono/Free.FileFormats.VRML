using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Material node specifies surface material properties for associated
	/// geometry nodes and is used by the X3D lighting equations during rendering.
	/// </summary>
	public class x3dMaterial : X3DNode, X3DMaterialNode
	{
		public double AmbientIntensity { get; set; }
		public SFColor DiffuseColor { get; set; }
		public SFColor EmissiveColor { get; set; }
		public double Shininess { get; set; }
		public SFColor SpecularColor { get; set; }
		public double Transparency { get; set; }

		public x3dMaterial()
		{
			AmbientIntensity=0.2;
			DiffuseColor=new SFColor(0.8, 0.8, 0.8);
			EmissiveColor=new SFColor(0, 0, 0);
			Shininess=0.2;
			SpecularColor=new SFColor(0, 0, 0);
			Transparency=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMaterialPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="ambientIntensity") AmbientIntensity=parser.ParseDoubleValue();
			else if(id=="diffuseColor") DiffuseColor=parser.ParseSFColorValue();
			else if(id=="emissiveColor") EmissiveColor=parser.ParseSFColorValue();
			else if(id=="shininess") Shininess=parser.ParseDoubleValue();
			else if(id=="specularColor") SpecularColor=parser.ParseSFColorValue();
			else if(id=="transparency") Transparency=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
