using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// X3DEnvironmentalSensorNode is the base type for the environmental
	/// sensor nodes ProximitySensor and VisibilitySensor.
	/// </summary>
	public interface X3DEnvironmentalSensorNode : X3DSensorNode
	{
		SFVec3f Center { get; set; }
		SFVec3f Size { get; set; }
	}
}
