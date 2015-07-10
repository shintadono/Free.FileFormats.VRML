using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A StringSensor node generates events as the user presses keys on the keyboard.
	/// </summary>
	public class x3dStringSensor : X3DNode, X3DKeyDeviceSensorNode
	{
		public bool DeletionAllowed { get; set; }
		public bool Enabled { get; set; }

		public x3dStringSensor()
		{
			DeletionAllowed=true;
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dStringSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="deletionAllowed") DeletionAllowed=parser.ParseBoolValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
