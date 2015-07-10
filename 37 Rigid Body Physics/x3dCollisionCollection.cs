using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCollisionCollection : X3DNode, X3DChildNode, IX3DCollisionCollectionNode
	{
		public List<string> AppliedParameters { get; set; }
		public double Bounce { get; set; }
		public List<IX3DCollisionCollectionCollidables> Collidables { get; set; }
		public bool Enabled { get; set; }
		public SFVec2f FrictionCoefficients { get; set; }
		public double MinBounceSpeed { get; set; }
		public SFVec2f SlipFactors { get; set; }
		public double SoftnessConstantForceMix { get; set; }
		public double SoftnessErrorCorrection { get; set; }
		public SFVec2f SurfaceSpeed { get; set; }

		bool wasAppliedParameters=false;

		public x3dCollisionCollection()
		{
			AppliedParameters=new List<string>();
			AppliedParameters.Add("BOUNCE");
			Bounce=0;
			Collidables=new List<IX3DCollisionCollectionCollidables>();
			Enabled=true;
			FrictionCoefficients=new SFVec2f(0, 0);
			MinBounceSpeed=0.1;
			SlipFactors=new SFVec2f(0, 0);
			SoftnessConstantForceMix=0.0001;
			SoftnessErrorCorrection=0.8;
			SurfaceSpeed=new SFVec2f(0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCollisionCollectionPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="appliedParameters")
			{
				if(wasAppliedParameters) AppliedParameters.AddRange(parser.ParseSFStringOrMFStringValue());
				AppliedParameters=parser.ParseSFStringOrMFStringValue();
				wasAppliedParameters=true;
			}
			else if(id=="bounce") Bounce=parser.ParseDoubleValue();
			else if(id=="collidables")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DCollisionCollectionCollidables colls=node as IX3DCollisionCollectionCollidables;
					if(colls==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Collidables.Add(colls);
				}
			}
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="frictionCoefficients") FrictionCoefficients=parser.ParseSFVec2fValue();
			else if(id=="minBounceSpeed") MinBounceSpeed=parser.ParseDoubleValue();
			else if(id=="slipFactors") SlipFactors=parser.ParseSFVec2fValue();
			else if(id=="softnessConstantForceMix") SoftnessConstantForceMix=parser.ParseDoubleValue();
			else if(id=="softnessErrorCorrection") SoftnessErrorCorrection=parser.ParseDoubleValue();
			else if(id=="surfaceSpeed") SurfaceSpeed=parser.ParseSFVec2fValue();
			else return false;
			return true;
		}
	}
}
