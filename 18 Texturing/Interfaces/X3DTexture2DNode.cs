using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DTexture2DNode : X3DTextureNode
	{
		bool RepeatS { get; set; }
		bool RepeatT { get; set; }
		IX3DTexturePropertiesNode TextureProperties { get; set; }
	}
}
