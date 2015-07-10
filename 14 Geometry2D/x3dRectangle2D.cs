using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Rectangle2D node specifies a rectangle centred at (0, 0) in
	/// the current local 2D coordinate system and aligned with the
	/// local coordinate axes.
	/// </summary>
	public class x3dRectangle2D : X3DNode, X3DGeometryNode
	{
		public SFVec2f Size { get; set; }
		public bool Solid { get; set; }

		public x3dRectangle2D()
		{
			Size=new SFVec2f(2, 2);
			Solid=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dRectangle2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="size") Size=parser.ParseSFVec2fValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
