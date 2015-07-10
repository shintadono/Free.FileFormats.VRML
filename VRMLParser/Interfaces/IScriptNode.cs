using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;

namespace Free.FileFormats.VRML.Interfaces
{
	internal interface IScriptNode
	{
		List<InterfaceDeclaration> ScriptingInterfaceDeclarations { get; set; }
	}
}
