using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dGeneratedCubeMapTexture : X3DNode, X3DEnvironmentTextureNode
	{
		public string Update { get; set; }
		public int Size { get; set; }
		public IX3DTexturePropertiesNode TextureProperties { get; set; }

		public x3dGeneratedCubeMapTexture()
		{
			Update="NONE";
			Size=128;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeneratedCubeMapTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="update") Update=parser.ParseStringValue();
			else if(id=="size") Size=parser.ParseIntValue();
			else if(id=="textureProperties")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TextureProperties=node as IX3DTexturePropertiesNode;
					if(TextureProperties==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
