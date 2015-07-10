namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DNBodyCollisionSpaceNode : X3DBoundedObject, IX3DCollisionCollectionCollidables
	{
		bool Enabled { get; set; }
	}
}
