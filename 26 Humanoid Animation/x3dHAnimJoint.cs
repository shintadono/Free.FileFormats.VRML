using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// Each joint in the body is represented by an HAnimJoint node, which
	/// is used to define the relationship of each body segment to its
	/// immediate parent.
	/// </summary>
	public class x3dHAnimJoint : X3DNode, X3DGroupingNode, IX3DHAnimHumanoidSkeleton, IX3DHAnimJointChildren, IX3DHAnimJointNode
	{
		public SFVec3f Center { get; set; }
		public List<X3DChildNode> Children { get; set; }
		public List<IX3DHAnimDisplacerNode> Displacers { get; set; }
		public SFRotation LimitOrientation { get; set; }
		public List<double> Llimit { get; set; }
		public string Name { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFRotation ScaleOrientation { get; set; }
		public List<int> SkinCoordIndex { get; set; }
		public List<double> SkinCoordWeight { get; set; }
		public List<double> Stiffness { get; set; }
		public SFVec3f Translation { get; set; }
		public List<double> Ulimit { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		bool wasStiffness=false;

		public x3dHAnimJoint()
		{
			Center=new SFVec3f(0, 0, 0);
			Children=new List<X3DChildNode>();
			Displacers=new List<IX3DHAnimDisplacerNode>();
			LimitOrientation=new SFRotation(0, 0, 1, 0);
			Llimit=new List<double>();
			Name="";
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			ScaleOrientation=new SFRotation(0, 0, 1, 0);
			SkinCoordIndex=new List<int>();
			SkinCoordWeight=new List<double>();
			Stiffness=new List<double>(new double[] { 0, 0, 0 });
			Translation=new SFVec3f(0, 0, 0);
			Ulimit=new List<double>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dHAnimJointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as IX3DHAnimJointChildren;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="displacers")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DHAnimDisplacerNode displacer=node as IX3DHAnimDisplacerNode;
					if(displacer==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Displacers.Add(displacer);
				}
			}
			else if(id=="limitOrientation") LimitOrientation=parser.ParseSFRotationValue();
			else if(id=="llimit") Llimit.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="name") Name=parser.ParseStringValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="scaleOrientation") ScaleOrientation=parser.ParseSFRotationValue();
			else if(id=="skinCoordIndex") SkinCoordIndex.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="skinCoordWeight") SkinCoordWeight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="stiffness")
			{
				if(wasStiffness) Stiffness.AddRange(parser.ParseSFFloatOrMFFloatValue());
				else Stiffness=parser.ParseSFFloatOrMFFloatValue();
				wasStiffness=true;
			}
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="ulimit") Ulimit.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
