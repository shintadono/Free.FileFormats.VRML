using System;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dConeEmitter : X3DNode, X3DParticleEmitterNode
	{
		public double Angle { get; set; }
		public SFVec3f Direction { get; set; }
		public SFVec3f Position { get; set; }
		public double Speed { get; set; }
		public double Variation { get; set; }
		public double Mass { get; set; }
		public double SurfaceArea { get; set; }

		public x3dConeEmitter()
		{
			Angle=Math.PI/4;
			Direction=new SFVec3f(0, 1, 0);
			Position=new SFVec3f(0, 0, 0);
			Speed=0;
			Variation=0.25;
			Mass=0;
			SurfaceArea=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dConeEmitterPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="angle") Angle=parser.ParseDoubleValue();
			else if(id=="direction") Direction=parser.ParseSFVec3fValue();
			else if(id=="position") Position=parser.ParseSFVec3fValue();
			else if(id=="speed") Speed=parser.ParseDoubleValue();
			else if(id=="variation") Variation=parser.ParseDoubleValue();
			else if(id=="mass") Mass=parser.ParseDoubleValue();
			else if(id=="surfaceArea") SurfaceArea=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
