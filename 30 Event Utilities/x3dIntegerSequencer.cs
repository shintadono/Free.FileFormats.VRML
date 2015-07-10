using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The IntegerSequencer node generates sequential discrete value_changed
	/// events selected from the keyValue field in response to each set_fraction,
	/// next, or previous event.
	/// </summary>
	public class x3dIntegerSequencer : X3DNode, X3DSequencerNode<SFInt32>
	{
		public List<double> Key { get; set; }
		public List<SFInt32> KeyValue { get; set; }

		public x3dIntegerSequencer()
		{
			Key=new List<double>();
			KeyValue=new List<SFInt32>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dIntegerSequencerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue")
			{
				List<int> values=parser.ParseSFInt32OrMFInt32Value();
				foreach(int value in values) KeyValue.Add(new SFInt32(value));
			}
			else return false;
			return true;
		}
	}
}
