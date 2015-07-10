using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The PositionInterpolator node linearly interpolates among a list of
	/// 2D vectors to produce an SFVec2f value_changed event.
	/// </summary>
	public class x3dPositionInterpolator2D : X3DNode, X3DInterpolatorNode<SFVec2f>
	{
		public List<double> Key { get; set; }
		public List<SFVec2f> KeyValue { get; set; }

		public x3dPositionInterpolator2D()
		{
			Key=new List<double>();
			KeyValue=new List<SFVec2f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPositionInterpolator2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else return false;
			return true;
		}
	}
}
