namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is used to derive node types that can emit audio data.
	/// </summary>
	public interface X3DSoundSourceNode : X3DTimeDependentNode
	{
		string Description { get; set; }
		double Pitch { get; set; }
	}
}
