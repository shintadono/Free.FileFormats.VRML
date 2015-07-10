using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Nodes;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		#region Nodes
		X3DNode GetNodeByName(string nodeTypeId)
		{
			#region ProtoNodePriorization==ProtoNodePriorization.ProtoNodeFirst
			if(errorHandling.ProtoNodePriorization==ProtoNodePriorization.ProtoNodeFirst)
			{
				if(protoDefinitions.ContainsKey(nodeTypeId))
				{
					// Make Copy
					X3DPrototypeInstance proto=((X3DNode)protoDefinitions[nodeTypeId]).GetProto();
					proto.InterfaceDeclarations=protoDefinitions[nodeTypeId].InterfaceDeclarations;
					proto.ProtoNodeName=protoDefinitions[nodeTypeId].ProtoNodeName;
					//proto.Nodes=protoDefinitions[nodeTypeId].Nodes;
					return (X3DNode)proto;
				}
			}
			#endregion

			X3DNode node=null;
			#region Bekannte Nodes
			switch(nodeTypeId[0])
			{
				case 'A':
					if(nodeTypeId=="Arc2D") node=new x3dArc2D();
					else if(nodeTypeId=="ArcClose2D") node=new x3dArcClose2D();
					else if(nodeTypeId=="Anchor") node=new x3dAnchor();
					else if(nodeTypeId=="Appearance") node=new x3dAppearance();
					else if(nodeTypeId=="AudioClip") node=new x3dAudioClip();
					break;
				case 'B':
					if(nodeTypeId=="Background") node=new x3dBackground();
					else if(nodeTypeId=="BallJoint") node=new x3dBallJoint();
					else if(nodeTypeId=="Billboard") node=new x3dBillboard();
					else if(nodeTypeId=="BooleanFilter") node=new x3dBooleanFilter();
					else if(nodeTypeId=="BooleanSequencer") node=new x3dBooleanSequencer();
					else if(nodeTypeId=="BooleanToggle") node=new x3dBooleanToggle();
					else if(nodeTypeId=="BooleanTrigger") node=new x3dBooleanTrigger();
					else if(nodeTypeId=="BoundedPhysicsModel") node=new x3dBoundedPhysicsModel();
					else if(nodeTypeId=="Box") node=new x3dBox();
					break;
				case 'C':
					if(nodeTypeId=="CADAssembly") node=new x3dCADAssembly();
					else if(nodeTypeId=="CADFace") node=new x3dCADFace();
					else if(nodeTypeId=="CADLayer") node=new x3dCADLayer();
					else if(nodeTypeId=="CADPart") node=new x3dCADPart();
					else if(nodeTypeId=="Circle2D") node=new x3dCircle2D();
					else if(nodeTypeId=="ClipPlane") node=new x3dClipPlane();
					else if(nodeTypeId=="CollidableOffset") node=new x3dCollidableOffset();
					else if(nodeTypeId=="CollidableShape") node=new x3dCollidableShape();
					else if(nodeTypeId=="Collision") node=new x3dCollision();
					else if(nodeTypeId=="CollisionCollection") node=new x3dCollisionCollection();
					else if(nodeTypeId=="CollisionSensor") node=new x3dCollisionSensor();
					else if(nodeTypeId=="CollisionSpace") node=new x3dCollisionSpace();
					else if(nodeTypeId=="Color") node=new x3dColor();
					else if(nodeTypeId=="ColorDamper") node=new x3dColorDamper();
					else if(nodeTypeId=="ColorInterpolator") node=new x3dColorInterpolator();
					else if(nodeTypeId=="ColorRGBA") node=new x3dColorRGBA();
					else if(nodeTypeId=="ComposedCubeMapTexture") node=new x3dComposedCubeMapTexture();
					else if(nodeTypeId=="ComposedShader") node=new x3dComposedShader();
					else if(nodeTypeId=="ComposedTexture3D"||nodeTypeId=="Composed3DTexture") node=new x3dComposedTexture3D();
					else if(nodeTypeId=="Cone") node=new x3dCone();
					else if(nodeTypeId=="ConeEmitter") node=new x3dConeEmitter();
					else if(nodeTypeId=="Contact") node=new x3dContact();
					else if(nodeTypeId=="Contour2D") node=new x3dContour2D();
					else if(nodeTypeId=="ContourPolyline2D") node=new x3dContourPolyline2D();
					else if(nodeTypeId=="Coordinate") node=new x3dCoordinate();
					else if(nodeTypeId=="CoordinateDamper") node=new x3dCoordinateDamper();
					else if(nodeTypeId=="CoordinateDeformer") node=new x3dCoordinateDeformer();
					else if(nodeTypeId=="CoordinateDouble") node=new x3dCoordinate();
					else if(nodeTypeId=="CoordinateInterpolator") node=new x3dCoordinateInterpolator();
					else if(nodeTypeId=="CoordinateInterpolator2D") node=new x3dCoordinateInterpolator2D();
					else if(nodeTypeId=="Cylinder") node=new x3dCylinder();
					else if(nodeTypeId=="CylinderSensor") node=new x3dCylinderSensor();
					break;
				case 'D':
					if(nodeTypeId=="DeviceManager") node=new x3dDeviceManager();
					else if(nodeTypeId=="DirectionalLight") node=new x3dDirectionalLight();
					else if(nodeTypeId=="DISEntityManager") node=new x3dDISEntityManager();
					else if(nodeTypeId=="DISEntityTypeMapping") node=new x3dDISEntityTypeMapping();
					else if(nodeTypeId=="Disk2D") node=new x3dDisk2D();
					else if(nodeTypeId=="DoubleAxisHingeJoint") node=new x3dDoubleAxisHingeJoint();
					break;
				case 'E':
					if(nodeTypeId=="EaseInEaseOut") node=new x3dEaseInEaseOut();
					else if(nodeTypeId=="ElevationGrid") node=new x3dElevationGrid();
					else if(nodeTypeId=="EspduTransform") node=new x3dEspduTransform();
					else if(nodeTypeId=="ExplosionEmitter") node=new x3dExplosionEmitter();
					else if(nodeTypeId=="Extrusion") node=new x3dExtrusion();
					break;
				case 'F':
					if(nodeTypeId=="FillProperties") node=new x3dFillProperties();
					else if(nodeTypeId=="FloatVertexAttribute") node=new x3dFloatVertexAttribute();
					else if(nodeTypeId=="Fog") node=new x3dFog();
					else if(nodeTypeId=="FogCoordinate") node=new x3dFogCoordinate();
					else if(nodeTypeId=="FontStyle") node=new x3dFontStyle();
					else if(nodeTypeId=="ForcePhysicsModel") node=new x3dForcePhysicsModel();
					break;
				case 'G':
					if(nodeTypeId=="GamepadSensor") node=new x3dGamepadSensor();
					else if(nodeTypeId=="GeneratedCubeMapTexture") node=new x3dGeneratedCubeMapTexture();
					else if(nodeTypeId=="GenericHIDSensor") node=new x3dGenericHIDSensor();
					else if(nodeTypeId=="GeoCoordinate") node=new x3dGeoCoordinate();
					else if(nodeTypeId=="GeoElevationGrid") node=new x3dGeoElevationGrid();
					else if(nodeTypeId=="GeoInline") node=new x3dInline();
					else if(nodeTypeId=="GeoLocation") node=new x3dGeoLocation();
					else if(nodeTypeId=="GeoLOD") node=new x3dGeoLOD();
					else if(nodeTypeId=="GeoMetadata") node=new x3dGeoMetadata();
					else if(nodeTypeId=="GeoOrigin") node=new x3dGeoOrigin();
					else if(nodeTypeId=="GeoPositionInterpolator") node=new x3dGeoPositionInterpolator();
					else if(nodeTypeId=="GeoProximitySensor") node=new x3dGeoProximitySensor();
					else if(nodeTypeId=="GeoTouchSensor") node=new x3dGeoTouchSensor();
					else if(nodeTypeId=="GeoTransform") node=new x3dGeoTransform();
					else if(nodeTypeId=="GeoViewpoint") node=new x3dGeoViewpoint();
					else if(nodeTypeId=="GravityPhysicsModel") node=new x3dForcePhysicsModel();
					else if(nodeTypeId=="Group") node=new x3dGroup();
					break;
				case 'H':
					if(nodeTypeId=="HAnimDisplacer") node=new x3dHAnimDisplacer();
					else if(nodeTypeId=="HAnimHumanoid") node=new x3dHAnimHumanoid();
					else if(nodeTypeId=="HAnimJoint") node=new x3dHAnimJoint();
					else if(nodeTypeId=="HAnimSegment") node=new x3dHAnimSegment();
					else if(nodeTypeId=="HAnimSite") node=new x3dHAnimSite();
					break;
				case 'I':
					if(nodeTypeId=="ImageCubeMapTexture") node=new x3dImageCubeMapTexture();
					else if(nodeTypeId=="ImageTexture") node=new x3dImageTexture();
					else if(nodeTypeId=="ImageTexture3D") node=new x3dImageTexture3D();
					else if(nodeTypeId=="IndexedFaceSet") node=new x3dIndexedFaceSet();
					else if(nodeTypeId=="IndexedLineSet") node=new x3dIndexedLineSet();
					else if(nodeTypeId=="IndexedQuadSet") node=new x3dIndexedQuadSet();
					else if(nodeTypeId=="IndexedTriangleFanSet") node=new x3dIndexedTriangleFanSet();
					else if(nodeTypeId=="IndexedTriangleSet") node=new x3dIndexedTriangleSet();
					else if(nodeTypeId=="IndexedTriangleStripSet") node=new x3dIndexedTriangleStripSet();
					else if(nodeTypeId=="Inline"||nodeTypeId=="InlineLoadControl") node=new x3dInline();
					else if(nodeTypeId=="IntegerSequencer") node=new x3dIntegerSequencer();
					else if(nodeTypeId=="IntegerTrigger") node=new x3dIntegerTrigger();
					break;
				case 'J':
					if(nodeTypeId=="JoystickSensor") node=new x3dJoystickSensor();
					break;
				case 'K':
					if(nodeTypeId=="KeySensor") node=new x3dKeySensor();
					else if(nodeTypeId=="KbdSensor") node=new dummyKbdSensor();
					break;
				case 'L':
					if(nodeTypeId=="Layer") node=new x3dLayer();
					else if(nodeTypeId=="LayerSet") node=new x3dLayerSet();
					else if(nodeTypeId=="Layout") node=new x3dLayout();
					else if(nodeTypeId=="LayoutGroup") node=new x3dLayoutGroup();
					else if(nodeTypeId=="LayoutLayer") node=new x3dLayoutLayer();
					else if(nodeTypeId=="LinePickSensor") node=new x3dLinePickSensor();
					else if(nodeTypeId=="LineProperties") node=new x3dLineProperties();
					else if(nodeTypeId=="LineSet") node=new x3dLineSet();
					else if(nodeTypeId=="LoadSensor") node=new x3dLoadSensor();
					else if(nodeTypeId=="LocalFog") node=new x3dLocalFog();
					else if(nodeTypeId=="LOD") node=new x3dLOD();
					break;
				case 'M':
					if(nodeTypeId=="Material") node=new x3dMaterial();
					else if(nodeTypeId=="Matrix3VertexAttribute") node=new x3dMatrix3VertexAttribute();
					else if(nodeTypeId=="Matrix4VertexAttribute") node=new x3dMatrix4VertexAttribute();
					else if(nodeTypeId=="MetadataBoolean") node=new x3dMetadataBoolean();
					else if(nodeTypeId=="MetadataDouble") node=new x3dMetadataDouble();
					else if(nodeTypeId=="MetadataFloat") node=new x3dMetadataFloat();
					else if(nodeTypeId=="MetadataInteger") node=new x3dMetadataInteger();
					else if(nodeTypeId=="MetadataSet") node=new x3dMetadataSet();
					else if(nodeTypeId=="MetadataString") node=new x3dMetadataString();
					else if(nodeTypeId=="MidiSensor") node=new x3dMidiSensor();
					else if(nodeTypeId=="MotorJoint") node=new x3dMotorJoint();
					else if(nodeTypeId=="MovieTexture") node=new x3dMovieTexture();
					else if(nodeTypeId=="MultiTexture") node=new x3dMultiTexture();
					else if(nodeTypeId=="MultiTextureCoordinate") node=new x3dMultiTextureCoordinate();
					else if(nodeTypeId=="MultiTextureTransform") node=new x3dMultiTextureTransform();
					else if(nodeTypeId=="MatrixTransform") node=new dummyMatrixTransform();
					break;
				case 'N':
					if(nodeTypeId=="NavigationInfo") node=new x3dNavigationInfo();
					else if(nodeTypeId=="Normal") node=new x3dNormal();
					else if(nodeTypeId=="NormalInterpolator") node=new x3dNormalInterpolator();
					else if(nodeTypeId=="NurbsCurve") node=new x3dNurbsCurve();
					else if(nodeTypeId=="NurbsCurve2D") node=new x3dNurbsCurve2D();
					else if(nodeTypeId=="NurbsOrientationInterpolator") node=new x3dNurbsOrientationInterpolator();
					else if(nodeTypeId=="NurbsPatchSurface"||nodeTypeId=="NurbsSurface") node=new x3dNurbsPatchSurface();
					else if(nodeTypeId=="NurbsPositionInterpolator") node=new x3dNurbsPositionInterpolator();
					else if(nodeTypeId=="NurbsSet") node=new x3dNurbsSet();
					else if(nodeTypeId=="NurbsSurfaceInterpolator") node=new x3dNurbsSurfaceInterpolator();
					else if(nodeTypeId=="NurbsSweptSurface") node=new x3dNurbsSweptSurface();
					else if(nodeTypeId=="NurbsSwungSurface") node=new x3dNurbsSwungSurface();
					else if(nodeTypeId=="NurbsTextureCoordinate") node=new x3dNurbsTextureCoordinate();
					else if(nodeTypeId=="NurbsTrimmedSurface") node=new x3dNurbsTrimmedSurface();
					break;
				case 'O':
					if(nodeTypeId=="OrientationChaser") node=new x3dOrientationChaser();
					else if(nodeTypeId=="OrientationDamper") node=new x3dOrientationDamper();
					else if(nodeTypeId=="OrientationInterpolator") node=new x3dOrientationInterpolator();
					else if(nodeTypeId=="OrthoViewpoint") node=new x3dOrthoViewpoint();
					break;
				case 'P':
					if(nodeTypeId=="PackagedShader") node=new x3dPackagedShader();
					else if(nodeTypeId=="ParticleSystem") node=new x3dParticleSystem();
					else if(nodeTypeId=="PickableGroup") node=new x3dPickableGroup();
					else if(nodeTypeId=="PixelTexture") node=new x3dPixelTexture();
					else if(nodeTypeId=="PixelTexture3D") node=new x3dPixelTexture3D();
					else if(nodeTypeId=="Pixel3DTexture") node=new x3dPixel3DTexture();
					else if(nodeTypeId=="PlaneSensor") node=new x3dPlaneSensor();
					else if(nodeTypeId=="PointEmitter") node=new x3dPointEmitter();
					else if(nodeTypeId=="PointLight") node=new x3dPointLight();
					else if(nodeTypeId=="PointPickSensor") node=new x3dPointPickSensor();
					else if(nodeTypeId=="PointSet") node=new x3dPointSet();
					else if(nodeTypeId=="Polyline2D") node=new x3dPolyline2D();
					else if(nodeTypeId=="PolylineEmitter") node=new x3dPolylineEmitter();
					else if(nodeTypeId=="Polypoint2D") node=new x3dPolypoint2D();
					else if(nodeTypeId=="PositionChaser") node=new x3dPositionChaser();
					else if(nodeTypeId=="PositionChaser2D") node=new x3dPositionChaser2D();
					else if(nodeTypeId=="PositionDamper") node=new x3dPositionDamper();
					else if(nodeTypeId=="PositionDamper2D") node=new x3dPositionDamper2D();
					else if(nodeTypeId=="PositionInterpolator") node=new x3dPositionInterpolator();
					else if(nodeTypeId=="PositionInterpolator2D") node=new x3dPositionInterpolator2D();
					else if(nodeTypeId=="PrimitivePicker"||nodeTypeId=="PrimitivePickSensor") node=new x3dPrimitivePicker();
					else if(nodeTypeId=="ProgramShader") node=new x3dProgramShader();
					else if(nodeTypeId=="ProximitySensor") node=new x3dProximitySensor();
					else if(nodeTypeId=="PolygonBackground") node=new dummyPolygonBackground();
					break;
				case 'Q':
					if(nodeTypeId=="QuadSet") node=new x3dQuadSet();
					break;
				case 'R':
					if(nodeTypeId=="ReceiverPdu") node=new x3dReceiverPdu();
					else if(nodeTypeId=="Rectangle2D") node=new x3dRectangle2D();
					else if(nodeTypeId=="RigidBody") node=new x3dRigidBody();
					else if(nodeTypeId=="RigidBodyCollection") node=new x3dRigidBodyCollection();
					break;
				case 'S':
					if(nodeTypeId=="ScalarChaser") node=new x3dScalarChaser();
					else if(nodeTypeId=="ScalarInterpolator") node=new x3dScalarInterpolator();
					else if(nodeTypeId=="ScreenFontStyle") node=new x3dScreenFontStyle();
					else if(nodeTypeId=="ScreenGround") node=new x3dScreenGround();
					else if(nodeTypeId=="Script") node=new x3dScript();
					else if(nodeTypeId=="ShaderPart") node=new x3dShaderPart();
					else if(nodeTypeId=="ShaderProgram") node=new x3dShaderProgram();
					else if(nodeTypeId=="Shape") node=new x3dShape();
					else if(nodeTypeId=="SignalPdu") node=new x3dSignalPdu();
					else if(nodeTypeId=="SingleAxisHingeJoint") node=new x3dSingleAxisHingeJoint();
					else if(nodeTypeId=="SliderJoint") node=new x3dSliderJoint();
					else if(nodeTypeId=="Sound") node=new x3dSound();
					else if(nodeTypeId=="Sphere") node=new x3dSphere();
					else if(nodeTypeId=="SphereSensor") node=new x3dSphereSensor();
					else if(nodeTypeId=="SplinePositionInterpolator") node=new x3dSplinePositionInterpolator();
					else if(nodeTypeId=="SplinePositionInterpolator2D") node=new x3dSplinePositionInterpolator2D();
					else if(nodeTypeId=="SplineScalarInterpolator") node=new x3dSplineScalarInterpolator();
					else if(nodeTypeId=="SpotLight") node=new x3dSpotLight();
					else if(nodeTypeId=="SquadOrientationInterpolator") node=new x3dSquadOrientationInterpolator();
					else if(nodeTypeId=="StaticGroup") node=new x3dStaticGroup();
					else if(nodeTypeId=="StringSensor") node=new x3dStringSensor();
					else if(nodeTypeId=="SurfaceEmitter") node=new x3dSurfaceEmitter();
					else if(nodeTypeId=="Switch") node=new x3dSwitch();
					else if(nodeTypeId=="SpaceSensor") node=new dummySpaceSensor();
					break;
				case 'T':
					if(nodeTypeId=="TexCoordDamper2D"||nodeTypeId=="TexCoordDamper") node=new x3dTexCoordDamper2D();
					else if(nodeTypeId=="Text") node=new x3dText();
					else if(nodeTypeId=="TextureBackground") node=new x3dTextureBackground();
					else if(nodeTypeId=="TextureCoordinate") node=new x3dTextureCoordinate();
					else if(nodeTypeId=="TextureCoordinate3D") node=new x3dTextureCoordinate3D();
					else if(nodeTypeId=="TextureCoordinate4D") node=new x3dTextureCoordinate4D();
					else if(nodeTypeId=="TextureCoordinateGenerator") node=new x3dTextureCoordinateGenerator();
					else if(nodeTypeId=="TextureProperties") node=new x3dTextureProperties();
					else if(nodeTypeId=="TextureTransform") node=new x3dTextureTransform();
					else if(nodeTypeId=="TextureTransform3D") node=new x3dTextureTransform3D();
					else if(nodeTypeId=="TextureTransformMatrix3D"||nodeTypeId=="TextureMatrixTransform") node=new x3dTextureTransformMatrix3D();
					else if(nodeTypeId=="TimeSensor") node=new x3dTimeSensor();
					else if(nodeTypeId=="TimeTrigger") node=new x3dTimeTrigger();
					else if(nodeTypeId=="TouchSensor") node=new x3dTouchSensor();
					else if(nodeTypeId=="TrackerSensor") node=new x3dTrackerSensor();
					else if(nodeTypeId=="Transform") node=new x3dTransform();
					else if(nodeTypeId=="TransformSensor") node=new x3dTransformSensor();
					else if(nodeTypeId=="TransmitterPdu") node=new x3dTransmitterPdu();
					else if(nodeTypeId=="TriangleFanSet") node=new x3dTriangleFanSet();
					else if(nodeTypeId=="TriangleSet") node=new x3dTriangleSet();
					else if(nodeTypeId=="TriangleSet2D") node=new x3dTriangleSet2D();
					else if(nodeTypeId=="TriangleStripSet") node=new x3dTriangleStripSet();
					else if(nodeTypeId=="TwoSidedMaterial") node=new x3dTwoSidedMaterial();
					else if(nodeTypeId=="Torus") node=new dummyTorus();
					break;
				case 'U':
					if(nodeTypeId=="UniversalJoint") node=new x3dUniversalJoint();
					break;
				case 'V':
					if(nodeTypeId=="Viewpoint") node=new x3dViewpoint();
					else if(nodeTypeId=="ViewpointGroup") node=new x3dViewpointGroup();
					else if(nodeTypeId=="Viewport") node=new x3dViewport();
					else if(nodeTypeId=="VisibilitySensor") node=new x3dVisibilitySensor();
					else if(nodeTypeId=="VolumeEmitter") node=new x3dVolumeEmitter();
					else if(nodeTypeId=="VolumePickSensor") node=new x3dVolumePickSensor();
					break;
				case 'W':
					if(nodeTypeId=="WheelSensor") node=new x3dWheelSensor();
					else if(nodeTypeId=="WindPhysicsModel") node=new x3dWindPhysicsModel();
					else if(nodeTypeId=="WorldInfo") node=new x3dWorldInfo();
					break;
			}
			#endregion

			if(errorHandling.ProtoNodePriorization==ProtoNodePriorization.ProtoNodeFirst) return node;

			if(node!=null) return node;

			if(protoDefinitions.ContainsKey(nodeTypeId))
			{
				if(errorHandling.ProtoNodePriorization==ProtoNodePriorization.ErrorProtoNodes)
					ErrorParsing(VRMLReaderError.ProtoFound, nodeTypeId);

				if(errorHandling.ProtoNodePriorization==ProtoNodePriorization.ProtoNodeSecondWarn)
					WriteWarning("Warning: (EXTERN)PROTO node used: '"+nodeTypeId+"' in line: "+line);

				// Make Copy
				X3DPrototypeInstance proto=((X3DNode)protoDefinitions[nodeTypeId]).GetProto();
				proto.InterfaceDeclarations=protoDefinitions[nodeTypeId].InterfaceDeclarations;
				proto.ProtoNodeName=protoDefinitions[nodeTypeId].ProtoNodeName;
				//proto.Nodes=protoDefinitions[nodeTypeId].Nodes;
				return (X3DNode)proto;
			}

			return null;
		}

		X3DNode ParseNode(string DEFName)
		{
			// nodeTypeId { nodeBody } | Script { scriptBody }

			string nodeTypeId=GetNextIDToken();

			char ts=GetNextTerminalSymbolToken();
			if(ts!='{') ErrorParsingToken("{", ts.ToString(), "node statement '"+nodeTypeId+"'");

			X3DNode node=GetNodeByName(nodeTypeId);

			bool returnNull=false;
			if(node is IDummyNode)
			{
				switch(errorHandling.DummyNode)
				{
					case DummyNodeHandling.Error:
						ErrorParsing(VRMLReaderError.UnexpectedNodeType, nodeTypeId);
						break;
					case DummyNodeHandling.Warn:
						WriteWarning("Warning: Non-standard node found: '"+nodeTypeId+"' that can and will be parsed in line: "+line);
						break;
					case DummyNodeHandling.Ignore:
						returnNull=true;
						break;
				}
			}

			if(node==null)
			{
				switch(errorHandling.UnknownNode)
				{
					case UnknownNodeHandling.ErrorUnknownNodes:
						ErrorParsing(VRMLReaderError.UnexpectedNodeType, nodeTypeId);
						break;
					case UnknownNodeHandling.WarnUnknownNodes:
						WriteWarning("Warning: Unknown node found: '"+nodeTypeId+"' in line: "+line);
						returnNull=true;
						break;
					case UnknownNodeHandling.ParseAsExternProtoWarn:
						WriteWarning("Warning: Unknown node found: '"+nodeTypeId+"', will be parsed as EXTRENPROTO in line: "+line);
						break;
					case UnknownNodeHandling.IgnoreUnknownNodes:
						returnNull=true;
						break;
				}

				EXTERNPROTO externProto=new EXTERNPROTO();
				externProto.ProtoNodeName=nodeTypeId;
				node=externProto;
			}

			if(DEFName!=null)
			{
				instances[DEFName]=node;
				node.NameDEF=DEFName;
			}

			if(node is IScriptNode) ParseScriptBody(node);
			else ParseNodeBody(node);

			ts=GetNextTerminalSymbolToken();
			if(ts!='}') ErrorParsingToken("}", ts.ToString(), "node statement '"+nodeTypeId+"'");

			return returnNull?null:node;
		}

		void ParseNodeBody(X3DNode node)
		{
			// nodeBodyElement | nodeBodyElement nodeBody | empty

			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='}') return; // done

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("statement keyword or field id", "", "node body");

				ParseNodeBodyElement(node, idToken.id);
			}
		}

		void ParseScriptBody(X3DNode node)
		{
			// scriptBodyElement | scriptBodyElement scriptBody | empty

			for(; ; )
			{
				object token=PeekNextToken();

				VRMLTokenTerminalSymbol tsToken=token as VRMLTokenTerminalSymbol;
				if(tsToken!=null&&tsToken.symbol=='}') return; // done

				VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
				if(idToken==null) ErrorParsingToken("statement keyword or field id", "", "script node body");

				ParseScriptBodyElement(node, idToken.id);
			}
		}

		void ParseScriptBodyElement(X3DNode node, string id)
		{
			// nodeBodyElement | interfaceDeclaration |
			// inputOnly fieldType inputOnlyId IS inputOnlyId |
			// outputOnly fieldType outputOnlyId IS outputOnlyId |
			// initializeOnly fieldType initializeOnlyId IS initializeOnlyId |
			// inputOutput fieldType inputOutputId IS inputOutputId

			IScriptNode script=node as IScriptNode;

			switch(id)
			{
				case "eventIn":
				case "inputOnly":
				case "eventOut":
				case "outputOnly":
					{
						string tokenEvent=GetNextIDToken();
						FieldType fieldType=GetNextFieldTypeToken();
						string eventId=GetNextIDToken();

						InterfaceDeclaration fieldDeclaration=new InterfaceDeclaration();
						fieldDeclaration.FieldId=eventId;
						fieldDeclaration.FieldType=fieldType;
						if(id=="eventIn"||id=="inputOnly")
							fieldDeclaration.InterfaceDeclarationType=InterfaceDeclarationType.EventIn;
						else fieldDeclaration.InterfaceDeclarationType=InterfaceDeclarationType.EventOut;

						if(inPROTO)
						{
							// Check if id is followed by IS Keyword
							object token=PeekNextToken();
							VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
							if(idToken!=null&&idToken.id=="IS")
							{
								string tokenIS=GetNextIDToken();
								string isID=GetNextIDToken();

								if(node.Substitutions.ContainsKey(eventId))
								{
									if(node.Substitutions[eventId]==isID) ErrorParsing(VRMLReaderError.RedundantISStatement);
									else ErrorParsing(VRMLReaderError.MultipleISStatementForField);
								}
								else node.Substitutions.Add(eventId, isID);
							}
						}

						script.ScriptingInterfaceDeclarations.Add(fieldDeclaration);
					}
					break;
				case "field":
				case "initializeOnly":
				case "exposedField":
				case "inputOutput":
					{
						string tokenEvent=GetNextIDToken();
						FieldType fieldType=GetNextFieldTypeToken();
						string fieldId=GetNextIDToken();

						InterfaceDeclaration fieldDeclaration=new InterfaceDeclaration();
						fieldDeclaration.FieldId=fieldId;
						fieldDeclaration.FieldType=fieldType;
						if(id=="field"||id=="initializeOnly")
							fieldDeclaration.InterfaceDeclarationType=InterfaceDeclarationType.Field;
						else fieldDeclaration.InterfaceDeclarationType=InterfaceDeclarationType.ExposedField;

						// Check if id is followed by IS Keyword
						object token=PeekNextToken();
						VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
						if(inPROTO&&idToken!=null&&idToken.id=="IS")
						{
							string tokenIS=GetNextIDToken();
							string isID=GetNextIDToken();

							if(node.Substitutions.ContainsKey(fieldId))
							{
								if(node.Substitutions[fieldId]==isID) ErrorParsing(VRMLReaderError.RedundantISStatement);
								else ErrorParsing(VRMLReaderError.MultipleISStatementForField);
							}
							else node.Substitutions.Add(fieldId, isID);
						}
						else fieldDeclaration.DefaultValue=ParseFieldByType(fieldType);

						script.ScriptingInterfaceDeclarations.Add(fieldDeclaration);
					}
					break;
				default: ParseNodeBodyElement(node, id); break;
			}
		}

		void ParseNodeBodyElement(X3DNode node, string id)
		{
			// initializeOnlyId fieldValue |
			// initializeOnlyId IS initializeOnlyId |
			// inputOnlyId IS inputOnlyId |
			// outputOnlyId IS outputOnlyId |
			// inputOutputId IS inputOutputId |
			// routeStatement | protoStatement

			switch(id)
			{
				case "PROTO":
				case "EXTERNPROTO":
					{
						string nodeTypeId;
						X3DPrototypeInstance proto=ParseProtoStatement(out nodeTypeId);
						protoDefinitions.Add(nodeTypeId, proto);
					}
					break;
				case "ROUTE": ParseRouteStatement(); break;
				default:
					{
						GetNextIDToken(); // id

						object token=PeekNextToken();
						VRMLTokenIdKeywordOrFieldType idToken=token as VRMLTokenIdKeywordOrFieldType;
						if(inPROTO&&(idToken!=null&&idToken.id=="IS"))
						{
							string tokenIS=GetNextIDToken();
							string isID=GetNextIDToken();

							if(node.Substitutions.ContainsKey(id))
							{
								if(node.Substitutions[id]==isID) ErrorParsing(VRMLReaderError.RedundantISStatement);
								else ErrorParsing(VRMLReaderError.MultipleISStatementForField);
							}
							else node.Substitutions.Add(id, isID);
						}
						else
						{
							if(id=="metadata")
							{
								X3DNode mdnode=ParseSFNodeValue();
								if(mdnode!=null)
								{
									node.Metadata=mdnode as X3DMetadataObject;
									if(node.Metadata==null) ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, node, id, mdnode, line);
								}
							}
							else
							{
								X3DPrototypeInstance proto=node as X3DPrototypeInstance;
								if(proto!=null)
								{
									InterfaceDeclaration decl=null;
									for(int i=0; i<proto.InterfaceDeclarations.Count; i++)
									{
										if(id==proto.InterfaceDeclarations[i].FieldId)
										{
											decl=proto.InterfaceDeclarations[i];
											break;
										}
									}

									if(decl!=null)
									{
										if(decl.InterfaceDeclarationType==InterfaceDeclarationType.EventIn||
											decl.InterfaceDeclarationType==InterfaceDeclarationType.EventOut)
											ErrorParsingNode(VRMLReaderError.UnknownFieldInNode, node, id, null, line);

										X3DFieldBase field=ParseFieldByType(decl.FieldType);
										if(field!=null) node.Fields[id]=field;
									}
									else
									{
										ErrorParsingNode(VRMLReaderError.UnknownFieldInNode, node, id, null, line);

										X3DFieldBase field=ParseUntypedFieldValue();
										if(field!=null) node.Fields[id]=field;
									}
								}
								else if(!node.ParseNodeBodyElement(id, this))
								{
									ErrorParsingNode(VRMLReaderError.UnknownFieldInNode, node, id, null, line);

									X3DFieldBase field=ParseUntypedFieldValue();
									if(field!=null) node.Fields[id]=field;
								}
							}
						}
					}
					break;
			}
		}
		#endregion
	}
}
