using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dJoystickSensorPROTO : x3dJoystickSensor, X3DPrototypeInstance
	{
		public List<InterfaceDeclaration> InterfaceDeclarations { get; set; }
		public string ProtoNodeName { get; set; }
		public List<X3DNode> Nodes { get; set; }
	}
}
