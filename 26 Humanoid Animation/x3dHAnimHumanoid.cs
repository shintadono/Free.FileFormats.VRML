using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The HAnimHumanoid node is used to store human-readable data such
	/// as author and copyright information, as well as to store references
	/// to the HAnimJoint, HAnimSegment, and HAnimSite nodes in addition to
	/// serving as a container for the entire humanoid. Thus, it serves as
	/// a central node for moving the humanoid through its environment.
	/// </summary>
	public class x3dHAnimHumanoid : X3DNode, X3DChildNode, X3DBoundedObject
	{
		public SFVec3f Center { get; set; }
		public List<string> Info { get; set; }
		public List<IX3DHAnimJointNode> Joints { get; set; }
		public string Name { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFRotation ScaleOrientation { get; set; }
		public List<IX3DHAnimeSegmentNode> Segments { get; set; }
		public List<IX3DHAnimSiteNode> Sites { get; set; }
		public List<IX3DHAnimHumanoidSkeleton> Skeleton { get; set; }
		public List<X3DChildNode> Skin { get; set; }
		public X3DCoordinateNode SkinCoord { get; set; }
		public X3DNormalNode SkinNormal { get; set; }
		public SFVec3f Translation { get; set; }
		public string Version { get; set; }
		public List<X3DViewpointNode> Viewpoints { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dHAnimHumanoid()
		{
			Center=new SFVec3f(0, 0, 0);
			Info=new List<string>();
			Joints=new List<IX3DHAnimJointNode>();
			Name="";
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			ScaleOrientation=new SFRotation(0, 0, 1, 0);
			Segments=new List<IX3DHAnimeSegmentNode>();
			Sites=new List<IX3DHAnimSiteNode>();
			Skeleton=new List<IX3DHAnimHumanoidSkeleton>();
			Skin=new List<X3DChildNode>();
			Translation=new SFVec3f(0, 0, 0);
			Version="";
			Viewpoints=new List<X3DViewpointNode>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dHAnimHumanoidPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="info") Info.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="joints")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DHAnimJointNode joint=node as IX3DHAnimJointNode;
					if(joint==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Joints.Add(joint);
				}
			}
			else if(id=="name") Name=parser.ParseStringValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="scaleOrientation") ScaleOrientation=parser.ParseSFRotationValue();
			else if(id=="segments")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DHAnimeSegmentNode segment=node as IX3DHAnimeSegmentNode;
					if(segment==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Segments.Add(segment);
				}
			}
			else if(id=="sites")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DHAnimSiteNode site=node as IX3DHAnimSiteNode;
					if(site==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Sites.Add(site);
				}
			}
			else if(id=="skeleton")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DHAnimHumanoidSkeleton skeleton=node as IX3DHAnimHumanoidSkeleton;
					if(skeleton==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Skeleton.Add(skeleton);
				}
			}
			else if(id=="skin")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode skin=node as X3DChildNode;
					if(skin==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Skin.Add(skin);
				}
			}
			else if(id=="skinCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					SkinCoord=node as X3DCoordinateNode;
					if(SkinCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="skinNormal")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					SkinNormal=node as X3DNormalNode;
					if(SkinNormal==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="version") Version=parser.ParseStringValue();
			else if(id=="viewpoints")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DViewpointNode vp=node as X3DViewpointNode; // x3d-Spec specs. x3dHAnimSite change to interface if neccessary
					if(vp==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Viewpoints.Add(vp);
				}
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
