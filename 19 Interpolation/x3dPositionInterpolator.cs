using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The PositionInterpolator node linearly interpolates among a list of
	/// 3D vectors to produce an SFVec3f value_changed event.
	/// </summary>
	public class x3dPositionInterpolator : X3DNode, X3DInterpolatorNode<SFVec3f>
	{
		public List<double> Key { get; set; }
		public List<SFVec3f> KeyValue { get; set; }

		public x3dPositionInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFVec3f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPositionInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else return false;
			return true;
		}
	}
}
