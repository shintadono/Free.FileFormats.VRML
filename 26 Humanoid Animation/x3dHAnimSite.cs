using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// An HAnimSite node serves three purposes.
	/// <para>* The first is to define an "end effecter" location that can be
	/// used by an inverse kinematics system.</para>
	/// <para>* The second is to define an attachment point for accessories such
	/// as jewelry and clothing.</para>
	/// <para>* The third is to define a location for a virtual camera in the
	/// reference frame of an HAnimSegment.
	/// </para>
	/// </summary>
	public class x3dHAnimSite : X3DNode, X3DGroupingNode, IX3DHAnimHumanoidSkeleton, IX3DHAnimJointChildren, IX3DHAnimSiteNode
	{
		public SFVec3f Center { get; set; }
		public List<X3DChildNode> Children { get; set; }
		public string Name { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFRotation ScaleOrientation { get; set; }
		public SFVec3f Translation { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dHAnimSite()
		{
			Center=new SFVec3f(0, 0, 0);
			Children=new List<X3DChildNode>();
			Name="";
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			ScaleOrientation=new SFRotation(0, 0, 1, 0);
			Translation=new SFVec3f(0, 0, 0);
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dHAnimSitePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="name") Name=parser.ParseStringValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="scaleOrientation") ScaleOrientation=parser.ParseSFRotationValue();
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
