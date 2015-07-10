namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the base node type from which all
	/// time-dependent nodes are derived.
	/// </summary>
	public interface X3DTimeDependentNode : X3DChildNode
	{
		bool Loop { get; set; }
		double PauseTime { get; set; }
		double ResumeTime { get; set; }
		double StartTime { get; set; }
		double StopTime { get; set; }
	}
}
