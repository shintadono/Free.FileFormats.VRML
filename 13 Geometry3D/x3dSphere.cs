using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Sphere node specifies a sphere centred at (0, 0, 0) in the local coordinate system.
	/// </summary>
	public class x3dSphere : X3DNode, X3DGeometryNode, IX3DPrimitivePickerPickingGeometry
	{
		public double Radius { get; set; }
		public bool Solid { get; set; }

		public x3dSphere()
		{
			Radius=1;
			Solid=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSpherePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="radius") Radius=parser.ParseDoubleValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
