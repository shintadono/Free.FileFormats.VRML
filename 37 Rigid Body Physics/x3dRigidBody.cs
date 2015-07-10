using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dRigidBody : X3DNode, IX3DRigidBodyNode
	{
		public double AngularDampingFactor { get; set; }
		public SFVec3f AngularVelocity { get; set; }
		public bool AutoDamp { get; set; }
		public bool AutoDisable { get; set; }
		public SFVec3f CenterOfMass { get; set; }
		public double DisableAngularSpeed { get; set; }
		public double DisableLinearSpeed { get; set; }
		public double DisableTime { get; set; }
		public bool Enabled { get; set; }
		public SFVec3f FiniteRotationAxis { get; set; }
		public bool Fixed { get; set; }
		public List<SFVec3f> Forces { get; set; }
		public List<X3DNBodyCollidableNode> Geometry { get; set; }
		public SFMatrix3f Inertia { get; set; }
		public double LinearDampingFactor { get; set; }
		public SFVec3f LinearVelocity { get; set; }
		public double Mass { get; set; }
		public X3DGeometryNode MassDensityModel { get; set; }
		public SFRotation Orientation { get; set; }
		public SFVec3f Position { get; set; }
		public List<SFVec3f> Torques { get; set; }
		public bool UseFiniteRotation { get; set; }
		public bool UseGlobalGravity { get; set; }

		public x3dRigidBody()
		{
			AngularDampingFactor=0.001;
			AngularVelocity=new SFVec3f(0, 0, 0);
			AutoDamp=false;
			AutoDisable=false;
			CenterOfMass=new SFVec3f(0, 0, 0);
			DisableAngularSpeed=0;
			DisableLinearSpeed=0;
			DisableTime=0;
			Enabled=true;
			FiniteRotationAxis=new SFVec3f(0, 0, 0);
			Fixed=false;
			Forces=new List<SFVec3f>();
			Geometry=new List<X3DNBodyCollidableNode>();
			Inertia=new SFMatrix3f(new List<double>(new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 }));
			LinearDampingFactor=0.001;
			LinearVelocity=new SFVec3f(0, 0, 0);
			Mass=1;
			Orientation=new SFRotation(0, 0, 1, 0);
			Position=new SFVec3f(0, 0, 0);
			Torques=new List<SFVec3f>();
			UseFiniteRotation=false;
			UseGlobalGravity=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dRigidBodyPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="angularDampingFactor") AngularDampingFactor=parser.ParseDoubleValue();
			else if(id=="angularVelocity") AngularVelocity=parser.ParseSFVec3fValue();
			else if(id=="autoDamp") AutoDamp=parser.ParseBoolValue();
			else if(id=="autoDisable") AutoDisable=parser.ParseBoolValue();
			else if(id=="centerOfMass") CenterOfMass=parser.ParseSFVec3fValue();
			else if(id=="disableAngularSpeed") DisableAngularSpeed=parser.ParseDoubleValue();
			else if(id=="disableLinearSpeed") DisableLinearSpeed=parser.ParseDoubleValue();
			else if(id=="disableTime") DisableTime=parser.ParseDoubleValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="finiteRotationAxis") FiniteRotationAxis=parser.ParseSFVec3fValue();
			else if(id=="fixed") Fixed=parser.ParseBoolValue();
			else if(id=="forces") Forces.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else if(id=="geometry")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DNBodyCollidableNode nbcn=node as X3DNBodyCollidableNode;
					if(nbcn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Geometry.Add(nbcn);
				}
			}
			else if(id=="inertia") Inertia=parser.ParseSFMatrix3fValue();
			else if(id=="linearDampingFactor") LinearDampingFactor=parser.ParseDoubleValue();
			else if(id=="linearVelocity") LinearVelocity=parser.ParseSFVec3fValue();
			else if(id=="mass") Mass=parser.ParseDoubleValue();
			else if(id=="massDensityModel")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					MassDensityModel=node as X3DGeometryNode;
					if(MassDensityModel==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="orientation") Orientation=parser.ParseSFRotationValue();
			else if(id=="position") Position=parser.ParseSFVec3fValue();
			else if(id=="torques") Torques.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else if(id=="useFiniteRotation") UseFiniteRotation=parser.ParseBoolValue();
			else if(id=="useGlobalGravity") UseGlobalGravity=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
