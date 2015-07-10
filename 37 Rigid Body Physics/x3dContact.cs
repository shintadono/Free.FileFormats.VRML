using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dContact : X3DNode
	{
		public List<string> AppliedParameters { get; set; }
		public x3dRigidBody Body1 { get; set; }
		public x3dRigidBody Body2 { get; set; }
		public double Bounce { get; set; }
		public SFVec3f ContactNormal { get; set; }
		public double Depth { get; set; }
		public SFVec2f FrictionCoefficients { get; set; }
		public SFVec3f FrictionDirection { get; set; }
		public X3DNBodyCollidableNode Geometry1 { get; set; }
		public X3DNBodyCollidableNode Geometry2 { get; set; }
		public double MinbounceSpeed { get; set; }
		public SFVec3f Position { get; set; }
		public SFVec2f SlipCoefficients { get; set; }
		public double SoftnessConstantForceMix { get; set; }
		public double SoftnessErrorCorrection { get; set; }
		public SFVec2f SurfaceSpeed { get; set; }

		bool wasAppliedParameters=false;

		public x3dContact()
		{
			AppliedParameters=new List<string>();
			AppliedParameters.Add("BOUNCE");
			Bounce=0;
			ContactNormal=new SFVec3f(0, 1, 0);
			Depth=0;
			FrictionCoefficients=new SFVec2f(0, 0);
			FrictionDirection=new SFVec3f(0, 1, 0);
			MinbounceSpeed=0;
			Position=new SFVec3f(0, 0, 0);
			SlipCoefficients=new SFVec2f(0, 0);
			SoftnessConstantForceMix=0.0001;
			SoftnessErrorCorrection=0.8;
			SurfaceSpeed=new SFVec2f(0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dContactPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="appliedParameters")
			{
				if(wasAppliedParameters) AppliedParameters.AddRange(parser.ParseSFStringOrMFStringValue());
				AppliedParameters=parser.ParseSFStringOrMFStringValue();
				wasAppliedParameters=true;
			}
			else if(id=="bounce") Bounce=parser.ParseDoubleValue();
			else if(id=="contactNormal") ContactNormal=parser.ParseSFVec3fValue();
			else if(id=="depth") Depth=parser.ParseDoubleValue();
			else if(id=="frictionCoefficients") FrictionCoefficients=parser.ParseSFVec2fValue();
			else if(id=="frictionDirection") FrictionDirection=parser.ParseSFVec3fValue();
			else if(id=="minbounceSpeed") MinbounceSpeed=parser.ParseDoubleValue();
			else if(id=="position") Position=parser.ParseSFVec3fValue();
			else if(id=="slipCoefficients") SlipCoefficients=parser.ParseSFVec2fValue();
			else if(id=="softnessConstantForceMix") SoftnessConstantForceMix=parser.ParseDoubleValue();
			else if(id=="softnessErrorCorrection") SoftnessErrorCorrection=parser.ParseDoubleValue();
			else if(id=="surfaceSpeed") SurfaceSpeed=parser.ParseSFVec2fValue();
			else return false;
			return true;
		}
	}
}
