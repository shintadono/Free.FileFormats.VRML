using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The DirectionalLight node defines a directional light source that
	/// illuminates along rays parallel to a given 3-dimensional vector.
	/// </summary>
	public class x3dDirectionalLight : X3DNode, X3DLightNode
	{
		public double AmbientIntensity { get; set; }
		public SFColor Color { get; set; }
		public SFVec3f Direction { get; set; }
		public bool Global { get; set; }
		public double Intensity { get; set; }
		public bool On { get; set; }

		public x3dDirectionalLight()
		{
			AmbientIntensity=0;
			Color=new SFColor(1, 1, 1);
			Direction=new SFVec3f(0, 0, -1);
			Global=false;
			Intensity=1;
			On=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dDirectionalLightPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="ambientIntensity") AmbientIntensity=parser.ParseDoubleValue();
			else if(id=="color") Color=parser.ParseSFColorValue();
			else if(id=="direction") Direction=parser.ParseSFVec3fValue();
			else if(id=="global") Global=parser.ParseBoolValue();
			else if(id=="intensity") Intensity=parser.ParseDoubleValue();
			else if(id=="on") On=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
