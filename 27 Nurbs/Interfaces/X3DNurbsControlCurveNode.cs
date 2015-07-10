using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// The X3DNurbsControlCurveNode abstract node type is the base type for
	/// all node types that provide control curve information in 2D space.
	/// </summary>
	public interface X3DNurbsControlCurveNode
	{
		List<SFVec2f> ControlPoint { get; set; }
	}
}
