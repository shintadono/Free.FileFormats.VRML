namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DLayerNode
	{
		bool IsPickable { get; set; }
		X3DViewportNode Viewport { get; set; }
	}
}
