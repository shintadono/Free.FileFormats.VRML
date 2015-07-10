using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dLayout : X3DNode, X3DLayoutNode
	{
		public List<string> Align { get; set; } // ["LEFT"|"CENTER"|"RIGHT", "BOTTOM"|"CENTER"|"TOP"]
		public List<double> Offset { get; set; }
		public List<string> OffsetUnits { get; set; } //["WORLD","FRACTION","PIXEL"]
		public List<string> ScaleMode { get; set; } //["NONE","FRACTION","STRETCH","PIXEL"]
		public List<double> Size { get; set; }
		public List<string> SizeUnits { get; set; } //["WORLD","FRACTION","PIXEL"]

		public x3dLayout()
		{
			Align=new List<string>();
			Align.Add("CENTER");
			Align.Add("CENTER");
			Offset=new List<double>();
			Offset.Add(0);
			Offset.Add(0);
			OffsetUnits=new List<string>();
			OffsetUnits.Add("WORLD");
			OffsetUnits.Add("WORLD");
			ScaleMode=new List<string>();
			ScaleMode.Add("NONE");
			ScaleMode.Add("NONE");
			Size=new List<double>();
			Size.Add(1);
			Size.Add(1);
			SizeUnits=new List<string>();
			SizeUnits.Add("WORLD");
			SizeUnits.Add("WORLD");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLayoutPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="align") Align=parser.ParseSFStringOrMFStringValue();
			else if(id=="offset") Offset=parser.ParseSFFloatOrMFFloatValue();
			else if(id=="offsetUnits") OffsetUnits=parser.ParseSFStringOrMFStringValue();
			else if(id=="scaleMode") ScaleMode=parser.ParseSFStringOrMFStringValue();
			else if(id=="size") Size=parser.ParseSFFloatOrMFFloatValue();
			else if(id=="sizeUnits") SizeUnits=parser.ParseSFStringOrMFStringValue();
			else return false;
			return true;
		}
	}
}
