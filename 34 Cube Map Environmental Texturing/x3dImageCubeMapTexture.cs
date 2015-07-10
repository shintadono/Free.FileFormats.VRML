using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dImageCubeMapTexture : X3DNode, X3DEnvironmentTextureNode, X3DUrlObject
	{
		public List<string> URL { get; set; }
		public IX3DTexturePropertiesNode TextureProperties { get; set; }

		public x3dImageCubeMapTexture()
		{
			URL=new List<string>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dImageCubeMapTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="url") URL=parser.ParseSFStringOrMFStringValue();
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
