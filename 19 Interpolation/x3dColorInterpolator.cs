using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// he ColorInterpolator node interpolates among a list of MFColor key values
	/// to produce an SFColor (RGB) value_changed event.
	/// </summary>
	public class x3dColorInterpolator : X3DNode, X3DInterpolatorNode<SFColor>
	{
		public List<double> Key { get; set; }
		public List<SFColor> KeyValue { get; set; }

		public x3dColorInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFColor>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dColorInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFColorOrMFColorValue());
			else return false;
			return true;
		}
	}
}
