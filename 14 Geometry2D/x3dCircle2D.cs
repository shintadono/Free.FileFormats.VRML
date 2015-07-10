using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Circle2D node specifies a circle centred at (0,0) in the local 2D coordinate system.
	/// </summary>
	public class x3dCircle2D : X3DNode, X3DGeometryNode
	{
		public double Radius { get; set; }

		public x3dCircle2D()
		{
			Radius=1;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCircle2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="radius") Radius=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
