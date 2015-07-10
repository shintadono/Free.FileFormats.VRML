using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dContourPolyline2DPROTO : x3dContourPolyline2D, X3DPrototypeInstance
	{
		public List<InterfaceDeclaration> InterfaceDeclarations { get; set; }
		public string ProtoNodeName { get; set; }
		public List<X3DNode> Nodes { get; set; }
	}
}
