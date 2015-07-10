using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dBallJoint : X3DNode, X3DRigidJointNode
	{
		public SFVec3f AnchorPoint { get; set; }
		public IX3DRigidBodyNode Body1 { get; set; }
		public IX3DRigidBodyNode Body2 { get; set; }
		public List<string> ForceOutput { get; set; }

		public bool wasForceOutput=false;

		public x3dBallJoint()
		{
			AnchorPoint=new SFVec3f(0, 0, 0);
			ForceOutput=new List<string>();
			ForceOutput.Add("NONE");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBallJointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="anchorPoint") AnchorPoint=parser.ParseSFVec3fValue();
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
			else return false;
			return true;
		}
	}
}
