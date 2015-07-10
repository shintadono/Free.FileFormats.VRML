using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// The X3DLightNode abstract node type is the base type from which all
	/// node types that serve as light sources are derived.
	/// </summary>
	public interface X3DLightNode : X3DChildNode
	{
		double AmbientIntensity { get; set; }
		SFColor Color { get; set; }
		bool Global { get; set; }
		double Intensity { get; set; }
		bool On { get; set; }
	}
}
