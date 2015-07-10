using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dComposedCubeMapTexture : X3DNode, X3DTextureNode
	{
		public X3DTexture2DNode Back { get; set; }
		public X3DTexture2DNode Bottom { get; set; }
		public X3DTexture2DNode Front { get; set; }
		public X3DTexture2DNode Left { get; set; }
		public X3DTexture2DNode Right { get; set; }
		public X3DTexture2DNode Top { get; set; }

		internal override X3DPrototypeInstance GetProto() { return new x3dComposedCubeMapTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="back")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Back=node as X3DTexture2DNode;
					if(Back==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="bottom")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Bottom=node as X3DTexture2DNode;
					if(Bottom==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="front")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Front=node as X3DTexture2DNode;
					if(Front==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="left")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Left=node as X3DTexture2DNode;
					if(Left==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="right")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Right=node as X3DTexture2DNode;
					if(Right==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="top")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Top=node as X3DTexture2DNode;
					if(Top==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
