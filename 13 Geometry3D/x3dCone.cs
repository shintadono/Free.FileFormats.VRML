using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Cone node specifies a cone which is centred in the local coordinate
	/// system and whose central axis is aligned with the local Y-axis.
	/// </summary>
	public class x3dCone : X3DNode, X3DGeometryNode, IX3DPrimitivePickerPickingGeometry
	{
		public bool Bottom { get; set; }
		public double BottomRadius { get; set; }
		public double Height { get; set; }
		public bool Side { get; set; }
		public bool Solid { get; set; }

		public x3dCone()
		{
			Bottom=true;
			BottomRadius=1;
			Height=2;
			Side=true;
			Solid=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dConePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="bottom") Bottom=parser.ParseBoolValue();
			else if(id=="bottomRadius") BottomRadius=parser.ParseDoubleValue();
			else if(id=="height") Height=parser.ParseDoubleValue();
			else if(id=="side") Side=parser.ParseBoolValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
