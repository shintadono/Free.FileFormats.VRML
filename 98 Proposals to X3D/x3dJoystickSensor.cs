using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dJoystickSensor : X3DNode, X3DHIDDeviceSensorNode
	{
		public bool Enabled { get; set; }
		public string Name { get; set; }

		public x3dJoystickSensor()
		{
			Enabled=true;
			Name="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dJoystickSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="name") Name=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
