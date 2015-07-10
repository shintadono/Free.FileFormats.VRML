using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Box node specifies a rectangular parallelepiped box centred at (0, 0, 0)
	/// in the local coordinate system and aligned with the local coordinate axes.
	/// </summary>
	public class x3dBox : X3DNode, X3DGeometryNode, IX3DPrimitivePickerPickingGeometry
	{
		public SFVec3f Size { get; set; }
		public bool Solid { get; set; }

		public x3dBox()
		{
			Size=new SFVec3f(2, 2, 2);
			Solid=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBoxPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="size") Size=parser.ParseSFVec3fValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
