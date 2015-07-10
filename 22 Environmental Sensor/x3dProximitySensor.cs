using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ProximitySensor node generates events when the viewer enters,
	/// exits, and moves within a region in space (defined by a box).
	/// </summary>
	public class x3dProximitySensor : X3DNode, X3DEnvironmentalSensorNode
	{
		public SFVec3f Center { get; set; }
		public bool Enabled { get; set; }
		public SFVec3f Size { get; set; }

		public x3dProximitySensor()
		{
			Center=new SFVec3f(0, 0, 0);
			Enabled=true;
			Size=new SFVec3f(0, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dProximitySensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="size") Size=parser.ParseSFVec3fValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
