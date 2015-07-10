using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A KeySensor node generates events when the user presses keys on the keyboard.
	/// </summary>
	public class x3dKeySensor : X3DNode, X3DKeyDeviceSensorNode
	{
		public bool Enabled { get; set; }

		public x3dKeySensor()
		{
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dKeySensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
