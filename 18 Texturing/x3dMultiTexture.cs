using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMultiTexture : X3DNode, X3DTextureNode
	{
		public double Alpha{ get; set; }
		public SFColor Color{ get; set; }
		public List<string> Function{ get; set; }
		public List<string> Mode{ get; set; }
		public List<string> Source{ get; set; }
		public List<X3DTextureNode> Texture{ get; set; }

		public x3dMultiTexture()
		{
			Alpha=1;
			Color=new SFColor(1, 1, 1);
			Function=new List<string>();
			Mode=new List<string>();
			Source=new List<string>();
			Texture=new List<X3DTextureNode>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMultiTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="alpha") Alpha=parser.ParseDoubleValue();
			else if(id=="color") Color=parser.ParseSFColorValue();
			else if(id=="function") Function=parser.ParseSFStringOrMFStringValue();
			else if(id=="mode") Mode=parser.ParseSFStringOrMFStringValue();
			else if(id=="source") Source=parser.ParseSFStringOrMFStringValue();
			else if(id=="texture")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DTextureNode tn=node as X3DTextureNode;
					if(tn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Texture.Add(tn);
				}
			}
			else return false;
			return true;
		}
	}
}
