using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dWheelSensor : X3DNode, X3DHIDDeviceSensorNode
	{
		public bool Enabled { get; set; }
		public string Name { get; set; }

		public x3dWheelSensor()
		{
			Enabled=true;
			Name="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dWheelSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="name") Name=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
