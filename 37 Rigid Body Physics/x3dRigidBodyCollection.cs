using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dRigidBodyCollection : X3DNode, X3DChildNode
	{
		public bool AutoDisable { get; set; }
		public List<IX3DRigidBodyNode> Bodies { get; set; }
		public double ConstantForceMix { get; set; }
		public double ContactSurfaceThickness { get; set; }
		public double DisableAngularSpeed { get; set; }
		public double DisableLinearSpeed { get; set; }
		public double DisableTime { get; set; }
		public bool Enabled { get; set; }
		public double ErrorCorrection { get; set; }
		public SFVec3f Gravity { get; set; }
		public int Iterations { get; set; }
		public List<X3DRigidJointNode> Joints { get; set; }
		public double MaxCorrectionSpeed { get; set; }
		public bool PreferAccuracy { get; set; }
		public IX3DCollisionCollectionNode Collider { get; set; }

		public x3dRigidBodyCollection()
		{
			AutoDisable=false;
			Bodies=new List<IX3DRigidBodyNode>();
			ConstantForceMix=0.0001;
			ContactSurfaceThickness=0;
			DisableAngularSpeed=0;
			DisableLinearSpeed=0;
			DisableTime=0;
			Enabled=true;
			ErrorCorrection=0.8;
			Gravity=new SFVec3f(0, -9.8, 0);
			Iterations=10;
			Joints=new List<X3DRigidJointNode>();
			MaxCorrectionSpeed=-1;
			PreferAccuracy=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dRigidBodyCollectionPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="autoDisable") AutoDisable=parser.ParseBoolValue();
			else if(id=="bodies")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DRigidBodyNode rb=node as IX3DRigidBodyNode;
					if(rb==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Bodies.Add(rb);
				}
			}
			else if(id=="constantForceMix") ConstantForceMix=parser.ParseDoubleValue();
			else if(id=="contactSurfaceThickness") ContactSurfaceThickness=parser.ParseDoubleValue();
			else if(id=="disableAngularSpeed") DisableAngularSpeed=parser.ParseDoubleValue();
			else if(id=="disableLinearSpeed") DisableLinearSpeed=parser.ParseDoubleValue();
			else if(id=="disableTime") DisableTime=parser.ParseDoubleValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="errorCorrection") ErrorCorrection=parser.ParseDoubleValue();
			else if(id=="gravity") Gravity=parser.ParseSFVec3fValue();
			else if(id=="iterations") Iterations=parser.ParseIntValue();
			else if(id=="joints")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DRigidJointNode rj=node as X3DRigidJointNode;
					if(rj==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Joints.Add(rj);
				}
			}
			else if(id=="maxCorrectionSpeed") MaxCorrectionSpeed=parser.ParseDoubleValue();
			else if(id=="preferAccuracy") PreferAccuracy=parser.ParseBoolValue();
			else if(id=="collider")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Collider=node as IX3DCollisionCollectionNode;
					if(Collider==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
