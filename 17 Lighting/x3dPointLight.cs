using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The PointLight node specifies a point light source at a 3D location
	/// in the local coordinate system.
	/// </summary>
	public class x3dPointLight : X3DNode, X3DLightNode
	{
		public double AmbientIntensity { get; set; }
		public SFVec3f Attenuation { get; set; }
		public SFColor Color { get; set; }
		public bool Global { get; set; }
		public double Intensity { get; set; }
		public SFVec3f Location { get; set; }
		public bool On { get; set; }
		public double Radius { get; set; }

		public x3dPointLight()
		{
			AmbientIntensity=0;
			Attenuation=new SFVec3f(1, 0, 0);
			Color=new SFColor(1, 1, 1);
			Global=true;
			Intensity=1;
			Location=new SFVec3f(0, 0, 0);
			On=true;
			Radius=100;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPointLightPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="ambientIntensity") AmbientIntensity=parser.ParseDoubleValue();
			else if(id=="attenuation") Attenuation=parser.ParseSFVec3fValue();
			else if(id=="color") Color=parser.ParseSFColorValue();
			else if(id=="global") Global=parser.ParseBoolValue();
			else if(id=="intensity") Intensity=parser.ParseDoubleValue();
			else if(id=="location") Location=parser.ParseSFVec3fValue();
			else if(id=="on") On=parser.ParseBoolValue();
			else if(id=="radius") Radius=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
