using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dComposedShader : X3DNode, X3DShaderNode, X3DProgrammableShaderObject, IScriptNode
	{
		public List<IX3DShaderPartNode> Parts { get; set; }
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

		public x3dComposedShader()
		{
			Parts=new List<IX3DShaderPartNode>();
			Language="";

			ScriptingInterfaceDeclarations=new List<InterfaceDeclaration>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dComposedShaderPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="parts")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DShaderPartNode shaderPart=node as IX3DShaderPartNode;
					if(shaderPart==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Parts.Add(shaderPart);
				}
			}
			else if(id=="language") Language=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
