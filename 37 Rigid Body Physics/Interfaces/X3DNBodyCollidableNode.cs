using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DNBodyCollidableNode : X3DChildNode, X3DBoundedObject, IX3DCollisionCollectionCollidables
	{
		bool Enabled { get; set; }
		SFRotation Rotation { get; set; }
		SFVec3f Translation { get; set; }
	}
}
