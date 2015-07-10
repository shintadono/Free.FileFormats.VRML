using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class dummyKbdSensor : X3DNode, X3DSensorNode, IDummyNode
	{
		// TODO
		// http://objectmix.com/vrml/191609-vrml-kbdsensor.html

		public bool Enabled { get; set; }

		public dummyKbdSensor()
		{
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new dummyKbdSensorPROTO(); }
	}
}
