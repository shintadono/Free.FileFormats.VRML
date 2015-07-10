using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ClipPlane node specifies a single plane equation that will be
	/// used to clip the geometry.
	/// </summary>
	public class x3dClipPlane : X3DNode, X3DChildNode
	{
		public bool Enabled { get; set; }
		public SFVec4f Plane { get; set; }

		public x3dClipPlane()
		{
			Enabled=true;
			Plane=new SFVec4f(0, 1, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dClipPlanePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="plane") Plane=parser.ParseSFVec4fValue();
			else return false;
			return true;
		}
	}
}
