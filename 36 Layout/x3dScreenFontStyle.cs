using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dScreenFontStyle : X3DNode, X3DFontStyleNode
	{
		public List<string> Family { get; set; }
		public bool Horizontal { get; set; }
		public List<string> Justify { get; set; }
		public string Language { get; set; }
		public bool LeftToRight { get; set; }
		public double PointSize { get; set; }
		public double Spacing { get; set; }
		public string Style { get; set; }
		public bool TopToBottom { get; set; }

		bool wasFamily=false, wasJustify=false;

		public x3dScreenFontStyle()
		{
			Family=new List<string>();
			Family.Add("SERIF");
			Horizontal=true;
			Justify=new List<string>();
			Justify.Add("BEGIN");
			Language="";
			LeftToRight=true;
			PointSize=1.0;
			Spacing=1.0;
			Style="PLAIN";
			TopToBottom=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dScreenFontStylePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="family")
			{
				if(wasFamily) Family.AddRange(parser.ParseSFStringOrMFStringValue());
				else Family=parser.ParseSFStringOrMFStringValue();
				wasFamily=true;
			}
			else if(id=="horizontal") Horizontal=parser.ParseBoolValue();
			else if(id=="justify")
			{
				if(wasJustify) Justify.AddRange(parser.ParseSFStringOrMFStringValue());
				else Justify=parser.ParseSFStringOrMFStringValue();
				wasJustify=true;
			}
			else if(id=="language") Language=parser.ParseStringValue();
			else if(id=="leftToRight") LeftToRight=parser.ParseBoolValue();
			else if(id=="pointSize") PointSize=parser.ParseDoubleValue();
			else if(id=="spacing") Spacing=parser.ParseDoubleValue();
			else if(id=="style") Style=parser.ParseStringValue();
			else if(id=="topToBottom") TopToBottom=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
