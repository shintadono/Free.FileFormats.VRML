using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The SplinePositionInterpolator node non-linearly interpolates among
	/// a list of 3D vectors to produce an SFVec3f value_changed event.
	/// </summary>
	public class x3dSplinePositionInterpolator : X3DNode, X3DInterpolatorNode<SFVec3f>
	{
		public bool Closed { get; set; }
		public List<double> Key { get; set; }
		public List<SFVec3f> KeyValue { get; set; }
		public List<SFVec3f> KeyVelocity { get; set; }
		public bool NormalizeVelocity { get; set; }

		public x3dSplinePositionInterpolator()
		{
			Closed=false;
			Key=new List<double>();
			KeyValue=new List<SFVec3f>();
			KeyVelocity=new List<SFVec3f>();
			NormalizeVelocity=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSplinePositionInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="closed") Closed=parser.ParseBoolValue();
			else if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else if(id=="keyVelocity") KeyVelocity.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else if(id=="normalizeVelocity") NormalizeVelocity=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
