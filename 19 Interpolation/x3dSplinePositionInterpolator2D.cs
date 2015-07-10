using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The SplinePositionInterpolator2D node non-linearly interpolates among
	/// a list of 2D vectors to produce an SFVec2f value_changed event.
	/// </summary>
	public class x3dSplinePositionInterpolator2D : X3DNode, X3DInterpolatorNode<SFVec2f>
	{
		public bool Closed { get; set; }
		public List<double> Key { get; set; }
		public List<SFVec2f> KeyValue { get; set; }
		public List<SFVec2f> KeyVelocity { get; set; }
		public bool NormalizeVelocity { get; set; }

		public x3dSplinePositionInterpolator2D()
		{
			Closed=false;
			Key=new List<double>();
			KeyValue=new List<SFVec2f>();
			KeyVelocity=new List<SFVec2f>();
			NormalizeVelocity=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSplinePositionInterpolator2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="closed") Closed=parser.ParseBoolValue();
			else if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="keyVelocity") KeyVelocity.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="normalizeVelocity") NormalizeVelocity=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
