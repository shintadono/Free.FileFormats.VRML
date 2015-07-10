using System.Collections.Generic;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type indicates that concrete node types derived
	/// from it contain children nodes and is the basis for all aggregation.
	/// </summary>
	public interface X3DGroupingNode : X3DChildNode, X3DBoundedObject,
		IX3DTranformSensorTargetObject, IX3DPickSensorNodePickTarget, IX3DCADAssemblyChildren
	{
		List<X3DChildNode> Children { get; set; }
	}
}
