namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the base type for all sensors.
	/// </summary>
	public interface X3DSensorNode : X3DChildNode
	{
		bool Enabled { get; set; }
	}
}
