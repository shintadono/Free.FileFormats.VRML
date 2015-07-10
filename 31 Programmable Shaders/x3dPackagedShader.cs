using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPackagedShader : X3DNode, X3DShaderNode, X3DUrlObject, X3DProgrammableShaderObject, IScriptNode
	{
		public List<string> URL { get; set; }
		public string Language { get; set; }

		// # And any number of:
		//  inputOnly fieldType inputOnlyId
		//  outputOnly fieldType outputOnlyId
		//  initializeOnly fieldType initializeOnlyId fieldValue
		//  inputOutput fieldType fieldId fieldValue
		// or if in Proto definition:
		//  inputOnly fieldType inputOnlyId IS inputOnlyId
		//  outputOnly fieldType outputOnlyId IS outputOnlyId
		//  initializeOnly fieldType initializeOnlyId IS initializeOnlyId
		//  inputOutput fieldType fieldId IS inputOutputId
		public List<InterfaceDeclaration> ScriptingInterfaceDeclarations { get; set; }

		public x3dPackagedShader()
		{
			URL=new List<string>();
			Language="";

			ScriptingInterfaceDeclarations=new List<InterfaceDeclaration>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPackagedShaderPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="language") Language=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
