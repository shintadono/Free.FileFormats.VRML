using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A background node that uses six static images to compose the backdrop.
	/// </summary>
	public class x3dBackground : X3DNode, X3DBackgroundNode
	{
		public List<double> GroundAngle { get; set; }
		public List<SFColor> GroundColor { get; set; }
		public List<string> BackUrl { get; set; }
		public List<string> BottomUrl { get; set; }
		public List<string> FrontUrl { get; set; }
		public List<string> LeftUrl { get; set; }
		public List<string> RightUrl { get; set; }
		public List<string> TopUrl { get; set; }
		public List<double> SkyAngle { get; set; }
		public List<SFColor> SkyColor { get; set; }
		public double Transparency { get; set; }

		bool wasSkyColor=false;

		public x3dBackground()
		{
			GroundAngle=new List<double>();
			GroundColor=new List<SFColor>();
			BackUrl=new List<string>();
			BottomUrl=new List<string>();
			FrontUrl=new List<string>();
			LeftUrl=new List<string>();
			RightUrl=new List<string>();
			TopUrl=new List<string>();
			SkyAngle=new List<double>();
			SkyColor=new List<SFColor>();
			SkyColor.Add(new SFColor(0, 0, 0));
			Transparency=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBackgroundPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="groundAngle") GroundAngle.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="groundColor") GroundColor.AddRange(parser.ParseSFColorOrMFColorValue());
			else if(id=="backUrl") BackUrl.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="bottomUrl") BottomUrl.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="frontUrl") FrontUrl.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="leftUrl") LeftUrl.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="rightUrl") RightUrl.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="topUrl") TopUrl.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="skyAngle") SkyAngle.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="skyColor")
			{
				if(wasSkyColor) SkyColor.AddRange(parser.ParseSFColorOrMFColorValue());
				else SkyColor=parser.ParseSFColorOrMFColorValue();
				wasSkyColor=true;
			}
			else if(id=="transparency")
			{
				// since X3D Node Spec and VRML Classic Coding Spec disagree on the fieldType
				List<double> values=parser.ParseSFFloatOrMFFloatValue();
				if(values.Count!=0) Transparency=values[0];
			}
			else return false;
			return true;
		}
	}
}
