using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Disk2D node specifies a circular disk which is
	/// centred at (0, 0) in the local coordinate system.
	/// </summary>
	public class x3dDisk2D : X3DNode, X3DGeometryNode
	{
		public double InnerRadius { get; set; }
		public double OuterRadius { get; set; }
		public bool Solid { get; set; }

		public x3dDisk2D()
		{
			InnerRadius=0;
			OuterRadius=1;
			Solid=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dDisk2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="innerRadius") InnerRadius=parser.ParseDoubleValue();
			else if(id=="outerRadius") OuterRadius=parser.ParseDoubleValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
