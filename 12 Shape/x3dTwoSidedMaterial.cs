using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node defines material properties that can effect both the front and
	/// back side of a polygon individually.
	/// </summary>
	public class x3dTwoSidedMaterial : X3DNode, X3DMaterialNode
	{
		public double AmbientIntensity { get; set; }
		public double BackAmbientIntensity { get; set; }
		public SFColor BackDiffuseColor { get; set; }
		public SFColor BackEmissiveColor { get; set; }
		public double BackShininess { get; set; }
		public SFColor BackSpecularColor { get; set; }
		public double BackTransparency { get; set; }
		public SFColor DiffuseColor { get; set; }
		public SFColor EmissiveColor { get; set; }
		public double Shininess { get; set; }
		public bool SeparateBackColor { get; set; }
		public SFColor SpecularColor { get; set; }
		public double Transparency { get; set; }

		public x3dTwoSidedMaterial()
		{
			AmbientIntensity=0.2;
			BackAmbientIntensity=0.2;
			BackDiffuseColor=new SFColor(0.8, 0.8, 0.8);
			BackEmissiveColor=new SFColor(0, 0, 0);
			BackShininess=0.2;
			BackSpecularColor=new SFColor(0, 0, 0);
			BackTransparency=0;
			DiffuseColor=new SFColor(0.8, 0.8, 0.8);
			EmissiveColor=new SFColor(0, 0, 0);
			Shininess=0.2;
			SeparateBackColor=false;
			SpecularColor=new SFColor(0, 0, 0);
			Transparency=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTwoSidedMaterialPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="ambientIntensity") AmbientIntensity=parser.ParseDoubleValue();
			else if(id=="backAmbientIntensity") BackAmbientIntensity=parser.ParseDoubleValue();
			else if(id=="backDiffuseColor") BackDiffuseColor=parser.ParseSFColorValue();
			else if(id=="backEmissiveColor") BackEmissiveColor=parser.ParseSFColorValue();
			else if(id=="backShininess") BackShininess=parser.ParseDoubleValue();
			else if(id=="backSpecularColor") BackSpecularColor=parser.ParseSFColorValue();
			else if(id=="backTransparency") BackTransparency=parser.ParseDoubleValue();
			else if(id=="diffuseColor") DiffuseColor=parser.ParseSFColorValue();
			else if(id=="emissiveColor") EmissiveColor=parser.ParseSFColorValue();
			else if(id=="shininess") Shininess=parser.ParseDoubleValue();
			else if(id=="separateBackColor") SeparateBackColor=parser.ParseBoolValue();
			else if(id=="specularColor") SpecularColor=parser.ParseSFColorValue();
			else if(id=="transparency") Transparency=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
