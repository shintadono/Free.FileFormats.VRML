using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DTexture3DNode : X3DTextureNode
	{
		bool RepeatS { get; set; }
		bool RepeatT { get; set; }
		bool RepeatR { get; set; }
		IX3DTexturePropertiesNode TextureProperties { get; set; }
	}
}
