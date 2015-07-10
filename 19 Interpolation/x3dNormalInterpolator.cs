using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NormalInterpolator node interpolates among a list of normal vector sets
	/// specified by the keyValue field to produce an MFVec3f value_changed event.
	/// </summary>
	public class x3dNormalInterpolator : X3DNode, X3DInterpolatorNode<SFVec3f>
	{
		public List<double> Key { get; set; }
		public List<SFVec3f> KeyValue { get; set; }

		public x3dNormalInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFVec3f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNormalInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else return false;
			return true;
		}
	}
}
