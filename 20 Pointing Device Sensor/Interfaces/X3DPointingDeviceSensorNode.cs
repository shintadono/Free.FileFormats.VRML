namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the base type for all pointing device sensors.
	/// </summary>
	public interface X3DPointingDeviceSensorNode : X3DSensorNode
	{
		string Description { get; set; }
	}
}
