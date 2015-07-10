using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ScalarInterpolator node linearly interpolates among a list of
	/// SFFloat values to produce an SFFloat value_changed event.
	/// </summary>
	public class x3dScalarInterpolator : X3DNode, X3DInterpolatorNode<SFFloat>
	{
		public List<double> Key { get; set; }
		public List<SFFloat> KeyValue { get; set; }

		public x3dScalarInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFFloat>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dScalarInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue")
			{
				List<double> values=parser.ParseSFFloatOrMFFloatValue();
				foreach(double value in values) KeyValue.Add(new SFFloat(value));
			}
			else return false;
			return true;
		}
	}
}
