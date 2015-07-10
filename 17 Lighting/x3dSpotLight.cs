using System;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The SpotLight node defines a light source that emits light from a specific
	/// point along a specific direction vector and constrained within a solid angle.
	/// </summary>
	public class x3dSpotLight : X3DNode, X3DLightNode
	{
		public double AmbientIntensity { get; set; }
		public SFVec3f Attenuation { get; set; }
		public double BeamWidth { get; set; }
		public SFColor Color { get; set; }
		public double CutOffAngle { get; set; }
		public SFVec3f Direction { get; set; }
		public bool Global { get; set; }
		public double Intensity { get; set; }
		public SFVec3f Location { get; set; }
		public bool On { get; set; }
		public double Radius { get; set; }

		public x3dSpotLight()
		{
			AmbientIntensity=0;
			Attenuation=new SFVec3f(1, 0, 0);
			BeamWidth=Math.PI/4;
			Color=new SFColor(1, 1, 1);
			CutOffAngle=Math.PI/2;
			Direction=new SFVec3f(0, 0, -1);
			Global=true;
			Intensity=1;
			Location=new SFVec3f(0, 0, 0);
			On=true;
			Radius=100;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSpotLightPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="ambientIntensity") AmbientIntensity=parser.ParseDoubleValue();
			else if(id=="attenuation") Attenuation=parser.ParseSFVec3fValue();
			else if(id=="beamWidth") BeamWidth=parser.ParseDoubleValue();
			else if(id=="color") Color=parser.ParseSFColorValue();
			else if(id=="cutOffAngle") CutOffAngle=parser.ParseDoubleValue();
			else if(id=="direction") Direction=parser.ParseSFVec3fValue();
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
