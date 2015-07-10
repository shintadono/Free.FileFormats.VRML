using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node defines a set of explicit fog depths on a per-vertex basis.
	/// </summary>
	public class x3dFogCoordinate : X3DNode, X3DGeometricPropertyNode, IX3DFogCoordinateNode
	{
		public List<double> Depth { get; set; }

		public x3dFogCoordinate()
		{
			Depth=new List<double>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dFogCoordinatePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="depth") Depth.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else return false;
			return true;
		}
	}
}
