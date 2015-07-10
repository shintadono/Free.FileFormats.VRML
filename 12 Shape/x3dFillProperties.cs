using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The FillProperties node specifies additional properties to be applied to
	/// all polygonal areas on top of whatever appearance is specified by the other
	/// fields of the respective Appearance node.
	/// </summary>
	public class x3dFillProperties : X3DNode, X3DAppearanceChildNode, IX3DFillPropertiesNode
	{
		public bool Filled { get; set; }
		public SFColor HatchColor { get; set; }
		public bool Hatched { get; set; }
		public int HatchStyle { get; set; }

		public x3dFillProperties()
		{
			Filled=true;
			HatchColor=new SFColor(1, 1, 1);
			Hatched=true;
			HatchStyle=1;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dFillPropertiesPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="filled") Filled=parser.ParseBoolValue();
			else if(id=="hatchColor") HatchColor=parser.ParseSFColorValue();
			else if(id=="hatched") Hatched=parser.ParseBoolValue();
			else if(id=="hatchStyle") HatchStyle=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
