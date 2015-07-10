using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMotorJoint : X3DNode, X3DRigidJointNode
	{
		public double Axis1Angle { get; set; }
		public double Axis1Torque { get; set; }
		public double Axis2Angle { get; set; }
		public double Axis2Torque { get; set; }
		public double Axis3Angle { get; set; }
		public double Axis3Torque { get; set; }
		public IX3DRigidBodyNode Body1 { get; set; }
		public IX3DRigidBodyNode Body2 { get; set; }
		public int EnabledAxes { get; set; }
		public List<string> ForceOutput { get; set; }
		public SFVec3f Motor1Axis { get; set; }
		public SFVec3f Motor2Axis { get; set; }
		public SFVec3f Motor3Axis { get; set; }
		public double Stop1Bounce { get; set; }
		public double Stop1ErrorCorrection { get; set; }
		public double Stop2Bounce { get; set; }
		public double Stop2ErrorCorrection { get; set; }
		public double Stop3Bounce { get; set; }
		public double Stop3ErrorCorrection { get; set; }
		public bool AutoCalc { get; set; }

		bool wasForceOutput=false;

		public x3dMotorJoint()
		{
			Axis1Angle=0;
			Axis1Torque=0;
			Axis2Angle=0;
			Axis2Torque=0;
			Axis3Angle=0;
			Axis3Torque=0;
			EnabledAxes=1;
			ForceOutput=new List<string>();
			ForceOutput.Add("NONE");
			Motor1Axis=new SFVec3f(0, 0, 0);
			Motor2Axis=new SFVec3f(0, 0, 0);
			Motor3Axis=new SFVec3f(0, 0, 0);
			Stop1Bounce=0;
			Stop1ErrorCorrection=0.8;
			Stop2Bounce=0;
			Stop2ErrorCorrection=0.8;
			Stop3Bounce=0;
			Stop3ErrorCorrection=0.8;
			AutoCalc=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMotorJointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="axis1Angle") Axis1Angle=parser.ParseDoubleValue();
			else if(id=="axis1Torque") Axis1Torque=parser.ParseDoubleValue();
			else if(id=="axis2Angle") Axis2Angle=parser.ParseDoubleValue();
			else if(id=="axis2Torque") Axis2Torque=parser.ParseDoubleValue();
			else if(id=="axis3Angle") Axis3Angle=parser.ParseDoubleValue();
			else if(id=="axis3Torque") Axis3Torque=parser.ParseDoubleValue();
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
			else if(id=="enabledAxes") EnabledAxes=parser.ParseIntValue();
			else if(id=="forceOutput")
			{
				if(wasForceOutput) ForceOutput.AddRange(parser.ParseSFStringOrMFStringValue());
				else ForceOutput=parser.ParseSFStringOrMFStringValue();
				wasForceOutput=true;
			}
			else if(id=="motor1Axis") Motor1Axis=parser.ParseSFVec3fValue();
			else if(id=="motor2Axis") Motor2Axis=parser.ParseSFVec3fValue();
			else if(id=="motor3Axis") Motor3Axis=parser.ParseSFVec3fValue();
			else if(id=="stop1Bounce") Stop1Bounce=parser.ParseDoubleValue();
			else if(id=="stop1ErrorCorrection") Stop1ErrorCorrection=parser.ParseDoubleValue();
			else if(id=="stop2Bounce") Stop2Bounce=parser.ParseDoubleValue();
			else if(id=="stop2ErrorCorrection") Stop2ErrorCorrection=parser.ParseDoubleValue();
			else if(id=="stop3Bounce") Stop3Bounce=parser.ParseDoubleValue();
			else if(id=="stop3ErrorCorrection") Stop3ErrorCorrection=parser.ParseDoubleValue();
			else if(id=="autoCalc") AutoCalc=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
