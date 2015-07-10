using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// BooleanSequencer generates sequential value_changed events selected
	/// from the keyValue field when driven from a TimeSensor clock.
	/// </summary>
	public class x3dBooleanSequencer : X3DNode, X3DSequencerNode<SFBool>
	{
		public List<double> Key { get; set; }
		public List<SFBool> KeyValue { get; set; }

		public x3dBooleanSequencer()
		{
			Key=new List<double>();
			KeyValue=new List<SFBool>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBooleanSequencerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue")
			{
				object token=parser.PeekNextToken();
				if(token is VRMLTokenString)
				{
					string values=parser.ParseStringValue();
					string[] parts=values.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

					foreach(string part in parts)
					{
						string l=part.ToLower();
						if(l=="true") KeyValue.Add(new SFBool(true));
						else KeyValue.Add(new SFBool(false));
					}
				}
				else
				{
					List<bool> values=parser.ParseSFBoolOrMFBoolValue();
					foreach(bool value in values) KeyValue.Add(new SFBool(value));
				}
			}
			else return false;
			return true;
		}
	}
}
