using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node linearly interpolates among a list of MFVec2f values
	/// to produce an MFVec2f value_changed event.
	/// </summary>
	public class x3dCoordinateInterpolator2D : X3DNode, X3DInterpolatorNode<SFVec2f>
	{
		public List<double> Key { get; set; }
		public List<SFVec2f> KeyValue { get; set; }

		public x3dCoordinateInterpolator2D()
		{
			Key=new List<double>();
			KeyValue=new List<SFVec2f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCoordinateInterpolator2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else return false;
			return true;
		}
	}
}
