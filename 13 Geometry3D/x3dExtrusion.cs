using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Extrusion node specifies geometric shapes based on a two dimensional
	/// cross-section extruded along a three dimensional spine in the local coordinate system.
	/// </summary>
	public class x3dExtrusion : X3DNode, X3DGeometryNode
	{
		public bool BeginCap { get; set; }
		public bool CCW { get; set; }
		public bool Convex { get; set; }
		public double CreaseAngle { get; set; }
		public List<SFVec2f> CrossSection { get; set; }
		public bool EndCap { get; set; }
		public List<SFRotation> Orientation { get; set; }
		public List<SFVec2f> Scale { get; set; }
		public bool Solid { get; set; }
		public List<SFVec3f> Spine { get; set; }

		bool wasCrossSection=false, wasOrientation=false, wasScale=false, wasSpine=false;

		public x3dExtrusion()
		{
			BeginCap=true;
			CCW=true;
			Convex=true;
			CreaseAngle=0;
			CrossSection=new List<SFVec2f>();
			CrossSection.Add(new SFVec2f(1, 1));
			CrossSection.Add(new SFVec2f(1, -1));
			CrossSection.Add(new SFVec2f(-1, -1));
			CrossSection.Add(new SFVec2f(-1, 1));
			CrossSection.Add(new SFVec2f(1, 1));
			EndCap=true;
			Orientation=new List<SFRotation>();
			Orientation.Add(new SFRotation(0, 0, 1, 0));
			Scale=new List<SFVec2f>();
			Scale.Add(new SFVec2f(1, 1));
			Solid=true;
			Spine=new List<SFVec3f>();
			Spine.Add(new SFVec3f(0, 0, 0));
			Spine.Add(new SFVec3f(0, 1, 0));
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dExtrusionPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="beginCap") BeginCap=parser.ParseBoolValue();
			else if(id=="ccw") CCW=parser.ParseBoolValue();
			else if(id=="convex") Convex=parser.ParseBoolValue();
			else if(id=="creaseAngle") CreaseAngle=parser.ParseDoubleValue();
			else if(id=="crossSection")
			{
				if(wasCrossSection) CrossSection.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
				else CrossSection=parser.ParseSFVec2fOrMFVec2fValue();
				wasCrossSection=true;
			}
			else if(id=="endCap") EndCap=parser.ParseBoolValue();
			else if(id=="orientation")
			{
				if(wasOrientation) Orientation.AddRange(parser.ParseSFRotationOrMFRotationValue());
				else Orientation=parser.ParseSFRotationOrMFRotationValue();
				wasOrientation=true;
			}
			else if(id=="scale")
			{
				if(wasScale) Scale.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
				else Scale=parser.ParseSFVec2fOrMFVec2fValue();
				wasScale=true;
			}
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else if(id=="spine")
			{
				if(wasSpine) Spine.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
				else Spine=parser.ParseSFVec3fOrMFVec3fValue();
				wasSpine=true;
			}
			else return false;
			return true;
		}
	}
}
