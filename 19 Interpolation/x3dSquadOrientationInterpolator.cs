using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The SquadOrientationInterpolator node non-linearly interpolates among
	/// a list of rotations to produce an SFRotation value_changed event.
	/// </summary>
	public class x3dSquadOrientationInterpolator : X3DNode, X3DInterpolatorNode<SFRotation>
	{
		public List<double> Key { get; set; }
		public List<SFRotation> KeyValue { get; set; }
		public bool NormalizeVelocity { get; set; }

		public x3dSquadOrientationInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFRotation>();
			NormalizeVelocity=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSquadOrientationInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFRotationOrMFRotationValue());
			else if(id=="normalizeVelocity") NormalizeVelocity=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
