using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DChaserNode<T> : X3DFollowerNode<T>
		where T : X3DFieldBase
	{
		double Duration { get; set; }
	}
}
