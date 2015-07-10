using System.Collections.Generic;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract interface is inherited by all nodes that contain data
	/// located on the World Wide Web, such as AudioClip, ImageTexture and Inline.
	/// </summary>
	public interface X3DUrlObject
	{
		List<string> URL { get; set; }
	}
}
