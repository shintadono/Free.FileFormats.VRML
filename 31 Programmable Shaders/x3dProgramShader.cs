using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dProgramShader : X3DNode, X3DShaderNode
	{
		public List<IX3DShaderProgramNode> Programs { get; set; }
		public string Language { get; set; }

		public x3dProgramShader()
		{
			Programs=new List<IX3DShaderProgramNode>();
			Language="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dProgramShaderPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="programs")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DShaderProgramNode sp=node as IX3DShaderProgramNode;
					if(sp==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Programs.Add(sp);
				}
			}
			else if(id=="language") Language=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
