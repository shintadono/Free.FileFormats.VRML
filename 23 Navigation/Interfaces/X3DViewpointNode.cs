using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// A node of node type X3DViewpointNode defines a specific location in
	/// the local coordinate system from which the user may view the scene.
	/// </summary>
	public interface X3DViewpointNode : X3DBindableNode, IX3DViewpointgroupChildren
	{
		SFVec3f CenterOfRotation { get; set; }
		string Description { get; set; }
		bool Jump { get; set; }
		SFRotation Orientation { get; set; }
		SFVec3f Position { get; set; }
		bool RetainUserOffsets { get; set; }
	}
}
