using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Nodes
{
	public class EXTERNPROTO : X3DNode, X3DPrototypeInstance,
		X3DAppearanceNode, X3DChildNode, X3DColorNode, X3DCoordinateNode, X3DFontStyleNode, X3DGeometryNode,
		X3DLayerNode, X3DLayoutNode, X3DMaterialNode, X3DMetadataObject, X3DNBodyCollidableNode, X3DNormalNode,
		X3DNurbsControlCurveNode, X3DNurbsSurfaceGeometryNode, X3DParticleEmitterNode, X3DParticlePhysicsModelNode,
		X3DPickSensorNode, X3DRigidJointNode, X3DShaderNode, X3DShapeNode, X3DSoundSourceNode, X3DTexture2DNode,
		X3DTextureCoordinateNode, X3DTextureNode, X3DTextureTransformNode, X3DUrlObject, X3DVertexAttributeNode,
		X3DViewpointNode, X3DViewportNode,

		// not needed, inhereted via other interfaces
		//+ X3DAppearanceChildNode, X3DBackgroundNode, X3DBindableNode, X3DBoundedObject, X3DChaserNode<>,
		//+ X3DComposedGeometryNode, X3DDamperNode<>, X3DDeviceSensorNode, X3DDragSensorNode,
		//+ X3DEnvironmentalSensorNode, X3DEnvironmentTextureNode, X3DFogObject, X3DFollowerNode<>,
		//+ X3DGeometricPropertyNode, X3DGroupingNode, X3DHIDDeviceSensorNode, X3DInfoNode,
		//+ X3DInterpolatorNode<>, X3DKeyDeviceSensorNode, X3DLightNode, X3DMidiDeviceSensorNode,
		//+ X3DNBodyCollisionSpaceNode, X3DNetworkSensorNode, X3DParametricGeometryNode, X3DPickableObject,
		//+ X3DPointingDeviceSensorNode, X3DProductStructureChildNode, X3DProgrammableShaderObject,
		//+ X3DScriptNode, X3DSensorNode, X3DSequencerNode<>, X3DSoundNode, X3DTexture3DNode,
		//+ X3DTimeDependentNode, X3DTouchSensorNode, X3DTrackerDeviceSensorNode, X3DTriggerNode,
		
		IX3DSummaryInterface
	{
		public List<InterfaceDeclaration> InterfaceDeclarations { get; set; }
		public string ProtoNodeName { get; set; }
		public List<X3DNode> Nodes { get; set; }
		public List<string> URLList { get; set; }

		public EXTERNPROTO()
		{
			ProtoNodeName="";
			URLList=new List<string>();
		}

		internal override X3DPrototypeInstance GetProto() { return new EXTERNPROTO(); }

		#region Dummy Implementations to satisfy compiler
		SFVec3f X3DBoundedObject.BBoxCenter { get; set; }
		SFVec3f X3DBoundedObject.BBoxSize { get; set; }
		List<X3DChildNode> X3DGroupingNode.Children { get; set; }
		bool X3DLayerNode.IsPickable { get; set; }
		X3DViewportNode X3DLayerNode.Viewport { get; set; }
		string X3DMetadataObject.Name { get; set; }
		string X3DMetadataObject.Reference { get; set; }
		bool X3DNBodyCollidableNode.Enabled { get; set; }
		SFRotation X3DNBodyCollidableNode.Rotation { get; set; }
		SFVec3f X3DNBodyCollidableNode.Translation { get; set; }
		List<SFVec2f> X3DNurbsControlCurveNode.ControlPoint { get; set; }
		X3DCoordinateNode X3DNurbsSurfaceGeometryNode.ControlPoint { get; set; }
		IX3DNurbsSurfaceGeometryNodeTexCoord X3DNurbsSurfaceGeometryNode.TexCoord { get; set; }
		int X3DNurbsSurfaceGeometryNode.UTessellation { get; set; }
		int X3DNurbsSurfaceGeometryNode.VTessellation { get; set; }
		List<double> X3DNurbsSurfaceGeometryNode.Weight { get; set; }
		bool X3DNurbsSurfaceGeometryNode.Solid { get; set; }
		bool X3DNurbsSurfaceGeometryNode.UClosed { get; set; }
		int X3DNurbsSurfaceGeometryNode.UDimension { get; set; }
		List<double> X3DNurbsSurfaceGeometryNode.UKnot { get; set; }
		int X3DNurbsSurfaceGeometryNode.UOrder { get; set; }
		bool X3DNurbsSurfaceGeometryNode.VClosed { get; set; }
		int X3DNurbsSurfaceGeometryNode.VDimension { get; set; }
		List<double> X3DNurbsSurfaceGeometryNode.VKnot { get; set; }
		int X3DNurbsSurfaceGeometryNode.VOrder { get; set; }
		double X3DParticleEmitterNode.Speed { get; set; }
		double X3DParticleEmitterNode.Variation { get; set; }
		double X3DParticleEmitterNode.Mass { get; set; }
		double X3DParticleEmitterNode.SurfaceArea { get; set; }
		bool X3DParticlePhysicsModelNode.Enabled { get; set; }
		List<string> X3DPickSensorNode.ObjectType { get; set; }
		X3DGeometryNode X3DPickSensorNode.PickingGeometry { get; set; }
		List<IX3DPickSensorNodePickTarget> X3DPickSensorNode.PickTarget { get; set; }
		string X3DPickSensorNode.IntersectionType { get; set; }
		string X3DPickSensorNode.SortOrder { get; set; }
		IX3DRigidBodyNode X3DRigidJointNode.Body1 { get; set; }
		IX3DRigidBodyNode X3DRigidJointNode.Body2 { get; set; }
		List<string> X3DRigidJointNode.ForceOutput { get; set; }
		bool X3DSensorNode.Enabled { get; set; }
		string X3DShaderNode.Language { get; set; }
		X3DAppearanceNode X3DShapeNode.Appearance { get; set; }
		X3DGeometryNode X3DShapeNode.Geometry { get; set; }
		string X3DSoundSourceNode.Description { get; set; }
		double X3DSoundSourceNode.Pitch { get; set; }
		bool X3DTexture2DNode.RepeatS { get; set; }
		bool X3DTexture2DNode.RepeatT { get; set; }
		IX3DTexturePropertiesNode X3DTexture2DNode.TextureProperties { get; set; }
		bool X3DTimeDependentNode.Loop { get; set; }
		double X3DTimeDependentNode.PauseTime { get; set; }
		double X3DTimeDependentNode.ResumeTime { get; set; }
		double X3DTimeDependentNode.StartTime { get; set; }
		double X3DTimeDependentNode.StopTime { get; set; }
		List<string> X3DUrlObject.URL { get; set; }
		string X3DVertexAttributeNode.Name { get; set; }
		SFVec3f X3DViewpointNode.CenterOfRotation { get; set; }
		string X3DViewpointNode.Description { get; set; }
		bool X3DViewpointNode.Jump { get; set; }
		SFRotation X3DViewpointNode.Orientation { get; set; }
		SFVec3f X3DViewpointNode.Position { get; set; }
		bool X3DViewpointNode.RetainUserOffsets { get; set; }
		SFVec3f IX3DGeoOriginNode.GeoCoords { get; set; }
		List<string> IX3DGeoOriginNode.GeoSystem { get; set; }
		bool IX3DGeoOriginNode.RotateYUp { get; set; }
		#endregion
	}

	interface IX3DSummaryInterface :
		IX3DCADAssemblyChildren, IX3DCADFaceNode, IX3DCADFaceShape, IX3DCollisionCollectionCollidables,
		IX3DCollisionCollectionNode, IX3DContour2DChildren, IX3DContour2DNode,
		IX3DCoordinateDeformerInputTransform, IX3DDISEntityTypeMappingNode, IX3DFillPropertiesNode,
		IX3DFogCoordinateNode, IX3DGeoOriginNode, IX3DHAnimDisplacerNode, IX3DHAnimeSegmentNode,
		IX3DHAnimHumanoidSkeleton, IX3DHAnimJointChildren, IX3DHAnimJointNode, IX3DHAnimSiteNode,
		IX3DLinePickSensorPickingGeometry, IX3DLinePropertiesNode, IX3DNurbsCurveNode,
		IX3DNurbsSurfaceGeometryNodeTexCoord, IX3DPickSensorNodePickTarget,
		IX3DPointPickSensorPickingGeometry, IX3DPrimitivePickerPickingGeometry, IX3DRigidBodyNode,
		IX3DShaderPartNode, IX3DShaderProgramNode, IX3DTexturePropertiesNode,
		IX3DTranformSensorTargetObject, IX3DViewpointgroupChildren
	{
	}
}
