using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dWindPhysicsModel : X3DNode, X3DParticlePhysicsModelNode
	{
		public SFVec3f Direction { get; set; }
		public bool Enabled { get; set; }
		public double Gustiness { get; set; }
		public double Speed { get; set; }
		public double Turbulence { get; set; }

		public x3dWindPhysicsModel()
		{
			Direction=new SFVec3f(0, 0, 0);
			Enabled=true;
			Gustiness=0.1;
			Speed=0.1;
			Turbulence=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dWindPhysicsModelPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="direction") Direction=parser.ParseSFVec3fValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="gustiness") Gustiness=parser.ParseDoubleValue();
			else if(id=="speed") Speed=parser.ParseDoubleValue();
			else if(id=="turbulence") Turbulence=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
