using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Cylinder node specifies a capped cylinder centred at (0,0,0)
	/// in the local coordinate system and with a central axis oriented
	/// along the local Y-axis.
	/// </summary>
	public class x3dCylinder : X3DNode, X3DGeometryNode, IX3DPrimitivePickerPickingGeometry
	{
		public bool Bottom { get; set; }
		public double Height { get; set; }
		public double Radius { get; set; }
		public bool Side { get; set; }
		public bool Solid { get; set; }
		public bool Top { get; set; }

		public x3dCylinder()
		{
			Bottom=true;
			Height=2;
			Radius=1;
			Side=true;
			Solid=true;
			Top=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCylinderPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="bottom") Bottom=parser.ParseBoolValue();
			else if(id=="height") Height=parser.ParseDoubleValue();
			else if(id=="radius") Radius=parser.ParseDoubleValue();
			else if(id=="side") Side=parser.ParseBoolValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else if(id=="top") Top=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
