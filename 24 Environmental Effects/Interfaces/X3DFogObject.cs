using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// X3DFogObject is the abstract type that describes a node that
	/// influences the lighting equation through the use of fog semantics.
	/// </summary>
	public interface X3DFogObject
	{
		SFColor Color { get; set; }
		string FogType { get; set; }
		double VisibilityRange { get; set; }
	}
}
