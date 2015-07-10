using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dUniversalJoint : X3DNode, X3DRigidJointNode
	{
		public SFVec3f AnchorPoint { get; set; }
		public SFVec3f Axis1 { get; set; }
		public SFVec3f Axis2 { get; set; }
		public IX3DRigidBodyNode Body1 { get; set; }
		public IX3DRigidBodyNode Body2 { get; set; }
		public List<string> ForceOutput { get; set; }
		public double Stop1Bounce { get; set; }
		public double Stop1ErrorCorrection { get; set; }
		public double Stop2Bounce { get; set; }
		public double Stop2ErrorCorrection { get; set; }

		public bool wasForceOutput=false;

		public x3dUniversalJoint()
		{
			AnchorPoint=new SFVec3f(0, 0, 0);
			Axis1=new SFVec3f(0, 0, 0);
			Axis2=new SFVec3f(0, 0, 0);
			ForceOutput=new List<string>();
			ForceOutput.Add("NONE");
			Stop1Bounce=0;
			Stop1ErrorCorrection=0.8;
			Stop2Bounce=0;
			Stop2ErrorCorrection=0.8;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dUniversalJointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="anchorPoint") AnchorPoint=parser.ParseSFVec3fValue();
			else if(id=="axis1") Axis1=parser.ParseSFVec3fValue();
			else if(id=="axis2") Axis2=parser.ParseSFVec3fValue();
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
			else if(id=="stop1Bounce"||id=="stopBounce1") Stop1Bounce=parser.ParseDoubleValue();
			else if(id=="stop1ErrorCorrection"||id=="stopErrorCorrection1") Stop1ErrorCorrection=parser.ParseDoubleValue();
			else if(id=="stop2Bounce"||id=="stopBounce2") Stop2Bounce=parser.ParseDoubleValue();
			else if(id=="stop2ErrorCorrection"||id=="stopErrorCorrection2") Stop2ErrorCorrection=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
