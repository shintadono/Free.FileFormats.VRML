using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The SplineScalarInterpolator node non-linearly interpolates among
	/// a list of floats to produce an SFFloat value_changed event.
	/// </summary>
	public class x3dSplineScalarInterpolator : X3DNode, X3DInterpolatorNode<SFFloat>
	{
		public bool Closed { get; set; }
		public List<double> Key { get; set; }
		public List<SFFloat> KeyValue { get; set; }
		public List<SFFloat> KeyVelocity { get; set; }
		public bool NormalizeVelocity { get; set; }

		public x3dSplineScalarInterpolator()
		{
			Closed=false;
			Key=new List<double>();
			KeyValue=new List<SFFloat>();
			KeyVelocity=new List<SFFloat>();
			NormalizeVelocity=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSplineScalarInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="closed") Closed=parser.ParseBoolValue();
			else if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue")
			{
				List<double> values=parser.ParseSFFloatOrMFFloatValue();
				foreach(double value in values) KeyValue.Add(new SFFloat(value));
			}
			else if(id=="keyVelocity")
			{
				List<double> values=parser.ParseSFFloatOrMFFloatValue();
				foreach(double value in values) KeyVelocity.Add(new SFFloat(value));
			}
			else if(id=="normalizeVelocity") NormalizeVelocity=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}

