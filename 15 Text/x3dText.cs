using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Text node specifies a two-sided, flat text string object positioned
	/// in the Z=0 plane of the local coordinate system based on values defined
	/// in the fontStyle field.
	/// </summary>
	public class x3dText : X3DNode, X3DGeometryNode
	{
		public X3DFontStyleNode FontStyle { get; set; }
		public List<double> Length { get; set; }
		public double MaxExtent { get; set; }
		public List<string> String { get; set; }
		public bool Solid { get; set; }

		public x3dText()
		{
			String=new List<string>();
			Length=new List<double>();
			MaxExtent=0.0;
			Solid=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="fontStyle")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					FontStyle=node as X3DFontStyleNode;
					if(FontStyle==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="length") Length.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="maxExtent") MaxExtent=parser.ParseDoubleValue();
			else if(id=="string") String.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
