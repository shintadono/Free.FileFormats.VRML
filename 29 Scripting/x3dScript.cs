using System.Collections.Generic;
using Free.FileFormats.VRML.InterfaceDeclarations;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Script node is used to program behaviour in a scene.
	/// </summary>
	public class x3dScript : X3DNode, X3DScriptNode, IScriptNode
	{
		public List<string> URL { get; set; }
		public bool DirectOutput { get; set; }
		public bool MustEvaluate { get; set; }

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

		public x3dScript()
		{
			URL=new List<string>();
			DirectOutput=false;
			MustEvaluate=false;

			ScriptingInterfaceDeclarations=new List<InterfaceDeclaration>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dScriptPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="directOutput") DirectOutput=parser.ParseBoolValue();
			else if(id=="mustEvaluate") MustEvaluate=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
