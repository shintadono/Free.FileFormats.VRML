using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DDamperNode<T> : X3DFollowerNode<T>
		where T : X3DFieldBase
	{
		double Tau { get; set; }
		double Tolerance { get; set; }
		int Order { get; set; }
	}
}
