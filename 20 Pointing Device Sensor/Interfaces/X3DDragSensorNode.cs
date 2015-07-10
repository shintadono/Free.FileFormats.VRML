namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the base type for all drag-style pointing device sensors.
	/// </summary>
	public interface X3DDragSensorNode : X3DPointingDeviceSensorNode
	{
		bool AutoOffset { get; set; }
	}
}
