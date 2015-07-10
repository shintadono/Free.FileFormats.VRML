using System.Collections.Generic;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DPickableObject
	{
		List<string> ObjectType { get; set; }
		bool Pickable { get; set; }
	}
}
