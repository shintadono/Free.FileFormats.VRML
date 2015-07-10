namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This is the base node type for all Shape nodes.
	/// </summary>
	public interface X3DShapeNode : X3DChildNode, X3DBoundedObject,
		IX3DTranformSensorTargetObject, IX3DPickSensorNodePickTarget, IX3DCADFaceShape
	{
		X3DAppearanceNode Appearance { get; set; }
		X3DGeometryNode Geometry { get; set; }
	}
}
