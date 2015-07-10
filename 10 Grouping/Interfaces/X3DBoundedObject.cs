using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the basis for all node types that have
	/// bounds specified as part of the definition.
	/// </summary>
	public interface X3DBoundedObject
	{
		SFVec3f BBoxCenter { get; set; }
		SFVec3f BBoxSize { get; set; }
	}
}
