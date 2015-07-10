using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dShaderProgram : X3DNode, X3DUrlObject, X3DProgrammableShaderObject, IX3DShaderProgramNode, IScriptNode
	{
		public List<string> URL { get; set; }
		public string Type { get; set; }

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

		public x3dShaderProgram()
		{
			URL=new List<string>();
			Type="";

			ScriptingInterfaceDeclarations=new List<InterfaceDeclaration>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dShaderProgramPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="type") Type=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
