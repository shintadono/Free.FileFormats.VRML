using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the base type for all prototype instances in
	/// the X3D system. Any user-defined nodes declared with PROTO or EXTERNPROTO
	/// are instantiated using this base type. An X3DPrototypeInstance may be
	/// place anywhere in the scene graph where it is legal to place the first
	/// node declared within the prototype instance.
	/// </summary>
	public interface X3DPrototypeInstance
	{
		// Implementation
		List<InterfaceDeclaration> InterfaceDeclarations { get; set; }
		string ProtoNodeName { get; set; }
		List<X3DNode> Nodes { get; set; }
	}
}
