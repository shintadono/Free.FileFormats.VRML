using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The CoordinateInterpolator node linearly interpolates among a list
	/// of MFVec3f values to produce an MFVec3f value_changed event.
	/// </summary>
	public class x3dCoordinateInterpolator : X3DNode, X3DInterpolatorNode<SFVec3f>
	{
		public List<double> Key { get; set; }
		public List<SFVec3f> KeyValue { get; set; }

		public x3dCoordinateInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFVec3f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCoordinateInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else return false;
			return true;
		}
	}
}
