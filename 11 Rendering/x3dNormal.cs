using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This node defines a set of 3D surface normal vectors to be used
	/// in the vector field of some geometry nodes.
	/// </summary>
	public class x3dNormal : X3DNode, X3DNormalNode
	{
		public List<SFVec3f> Vector { get; set; }

		public x3dNormal()
		{
			Vector=new List<SFVec3f>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNormalPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="vector") Vector.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else return false;
			return true;
		}
	}
}
