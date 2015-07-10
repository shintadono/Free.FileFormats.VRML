using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dForcePhysicsModel : X3DNode, X3DParticlePhysicsModelNode
	{
		public bool Enabled { get; set; }
		public SFVec3f Force { get; set; }

		public x3dForcePhysicsModel()
		{
			Enabled=true;
			Force=new SFVec3f(0, -9.8, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dForcePhysicsModelPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="force") Force=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
