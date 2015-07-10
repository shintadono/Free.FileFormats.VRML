using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The EaseInEaseOut node supports controlled gradual transitions by
	/// specifying modifications for TimeSensor node fractions.
	/// </summary>
	public class x3dEaseInEaseOut : X3DNode
	{
		public List<SFVec2f> EaseInEaseOut { get; set; }
		public List<double> Key { get; set; }

		public x3dEaseInEaseOut()
		{
			EaseInEaseOut=new List<SFVec2f>();
			Key=new List<double>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dEaseInEaseOutPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="easeInEaseOut") EaseInEaseOut.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else return false;
			return true;
		}
	}
}
