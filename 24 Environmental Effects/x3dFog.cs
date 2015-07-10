using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Fog node provides a way to simulate atmospheric effects by
	/// blending objects with the colour specified by the color field
	/// based on the distances of the various objects from the viewer.
	/// </summary>
	public class x3dFog : X3DNode, X3DBindableNode, X3DFogObject
	{
		public SFColor Color { get; set; }
		public string FogType { get; set; }
		public double VisibilityRange { get; set; }

		public x3dFog()
		{
			Color=new SFColor(1, 1, 1);
			FogType="LINEAR";
			VisibilityRange=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dFogPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="color") Color=parser.ParseSFColorValue();
			else if(id=="fogType") FogType=parser.ParseStringValue();
			else if(id=="visibilityRange") VisibilityRange=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
