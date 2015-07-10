using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DFollowerNode<T> : X3DChildNode
		where T : X3DFieldBase
	{
		T InitialDestination { get; set; }
		T InitialValue { get; set; }
	}
}
