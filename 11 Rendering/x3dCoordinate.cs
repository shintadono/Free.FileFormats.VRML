using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node defines a set of 3D coordinates to be used in the coord field of
	/// vertex-based geometry nodes.
	/// </summary>
	public class x3dCoordinate : X3DNode, X3DCoordinateNode
	{
		public List<SFVec3f> Point { get; set; }

		public x3dCoordinate()
		{
			Point=new List<SFVec3f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCoordinatePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="point"||id=="points") Point.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else return false;
			return true;
		}
	}
}
