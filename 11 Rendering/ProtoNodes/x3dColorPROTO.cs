using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dColorPROTO : x3dColor, X3DPrototypeInstance
	{
		public List<InterfaceDeclaration> InterfaceDeclarations { get; set; }
		public string ProtoNodeName { get; set; }
		public List<X3DNode> Nodes { get; set; }
	}
}
