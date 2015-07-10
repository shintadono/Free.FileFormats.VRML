using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dDoubleAxisHingeJoint : X3DNode, X3DRigidJointNode
	{
		public SFVec3f AnchorPoint { get; set; }
		public SFVec3f Axis1 { get; set; }
		public SFVec3f Axis2 { get; set; }
		public IX3DRigidBodyNode Body1 { get; set; }
		public IX3DRigidBodyNode Body2 { get; set; }
		public double DesiredAngularVelocity1 { get; set; }
		public double DesiredAngularVelocity2 { get; set; }
		public List<string> ForceOutput { get; set; }
		public double MaxAngle1 { get; set; }
		public double MaxTorque1 { get; set; }
		public double MaxTorque2 { get; set; }
		public double MinAngle1 { get; set; }
		public double StopBounce1 { get; set; }
		public double StopConstantForceMix1 { get; set; }
		public double StopErrorCorrection1 { get; set; }
		public double SuspensionErrorCorrection { get; set; }
		public double SuspensionForce { get; set; }

		public bool wasForceOutput=false;

		public x3dDoubleAxisHingeJoint()
		{
			AnchorPoint=new SFVec3f(0, 0, 0);
			Axis1=new SFVec3f(0, 0, 0);
			Axis2=new SFVec3f(0, 0, 0);
			DesiredAngularVelocity1=0;
			DesiredAngularVelocity2=0;
			ForceOutput=new List<string>();
			ForceOutput.Add("NONE");
			MaxAngle1=Math.PI;
			MaxTorque1=0;
			MaxTorque2=0;
			MinAngle1=-Math.PI;
			StopBounce1=0;
			StopConstantForceMix1=0.001;
			StopErrorCorrection1=0.8;
			SuspensionErrorCorrection=0.8;
			SuspensionForce=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dDoubleAxisHingeJointPROTO(); }

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
			else if(id=="desiredAngularVelocity1") DesiredAngularVelocity1=parser.ParseDoubleValue();
			else if(id=="desiredAngularVelocity2") DesiredAngularVelocity2=parser.ParseDoubleValue();
			else if(id=="forceOutput"||id=="mustOutput")
			{
				if(wasForceOutput) ForceOutput.AddRange(parser.ParseSFStringOrMFStringValue());
				else ForceOutput=parser.ParseSFStringOrMFStringValue();
				wasForceOutput=true;
			}
			else if(id=="maxAngle1") MaxAngle1=parser.ParseDoubleValue();
			else if(id=="maxTorque1") MaxTorque1=parser.ParseDoubleValue();
			else if(id=="maxTorque2") MaxTorque2=parser.ParseDoubleValue();
			else if(id=="minAngle1") MinAngle1=parser.ParseDoubleValue();
			else if(id=="stopBounce1") StopBounce1=parser.ParseDoubleValue();
			else if(id=="stopConstantForceMix1") StopConstantForceMix1=parser.ParseDoubleValue();
			else if(id=="stopErrorCorrection1") StopErrorCorrection1=parser.ParseDoubleValue();
			else if(id=="suspensionErrorCorrection") SuspensionErrorCorrection=parser.ParseDoubleValue();
			else if(id=="suspensionForce") SuspensionForce=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
