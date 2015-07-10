using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The OrientationInterpolator node interpolates among a list of rotation values
	/// specified in the keyValue field to produce an SFRotation value_changed event.
	/// </summary>
	public class x3dOrientationInterpolator : X3DNode, X3DInterpolatorNode<SFRotation>
	{
		public List<double> Key { get; set; }
		public List<SFRotation> KeyValue { get; set; }

		public x3dOrientationInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFRotation>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dOrientationInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFRotationOrMFRotationValue());
			else return false;
			return true;
		}
	}
}
