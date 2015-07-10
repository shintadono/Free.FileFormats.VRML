using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dSliderJoint : X3DNode, X3DRigidJointNode
	{
		public SFVec3f Axis { get; set; }
		public IX3DRigidBodyNode Body1 { get; set; }
		public IX3DRigidBodyNode Body2 { get; set; }
		public List<string> ForceOutput { get; set; }
		public double MaxSeparation { get; set; }
		public double MinSeparation { get; set; }
		public double SliderForce { get; set; }
		public double StopBounce { get; set; }
		public double StopErrorCorrection { get; set; }

		public bool wasForceOutput=false;

		public x3dSliderJoint()
		{
			Axis=new SFVec3f(0, 1, 0);
			ForceOutput=new List<string>();
			ForceOutput.Add("NONE");
			MaxSeparation=1;
			MinSeparation=0;
			SliderForce=0;
			StopBounce=0;
			StopErrorCorrection=1;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSliderJointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="axis") Axis=parser.ParseSFVec3fValue();
			else if(id=="body1")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Body1=node as IX3DRigidBodyNode;
					if(Body1==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="body2")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Body2=node as IX3DRigidBodyNode;
					if(Body2==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="forceOutput"||id=="mustOutput")
			{
				if(wasForceOutput) ForceOutput.AddRange(parser.ParseSFStringOrMFStringValue());
				else ForceOutput=parser.ParseSFStringOrMFStringValue();
				wasForceOutput=true;
			}
			else if(id=="maxSeparation") MaxSeparation=parser.ParseDoubleValue();
			else if(id=="minSeparation") MinSeparation=parser.ParseDoubleValue();
			else if(id=="sliderForce") SliderForce=parser.ParseDoubleValue();
			else if(id=="stopBounce") StopBounce=parser.ParseDoubleValue();
			else if(id=="stopErrorCorrection") StopErrorCorrection=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
