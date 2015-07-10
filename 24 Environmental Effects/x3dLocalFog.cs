using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The LocalFog node provides a way to simulate atmospheric effects
	/// by blending objects with the colour specified by the color field
	/// based on the distances of the various objects from the viewer.
	/// </summary>
	public class x3dLocalFog : X3DNode, X3DChildNode, X3DFogObject
	{
		public SFColor Color { get; set; }
		public bool Enabled { get; set; }
		public string FogType { get; set; }
		public double VisibilityRange { get; set; }

		public x3dLocalFog()
		{
		Color=new SFColor(1, 1, 1);
		Enabled=true;
		FogType="LINEAR";// ["LINEAR"|"EXPONENTIAL"]
		VisibilityRange=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLocalFogPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="color") Color=parser.ParseSFColorValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="fogType") FogType=parser.ParseStringValue();
			else if(id=="visibilityRange") VisibilityRange=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
