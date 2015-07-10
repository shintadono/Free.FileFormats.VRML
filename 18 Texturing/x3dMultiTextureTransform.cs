using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMultiTextureTransform : X3DNode, X3DTextureTransformNode
	{
		public List<X3DTextureTransformNode> TextureTransform { get; set; }

		public x3dMultiTextureTransform()
		{
			TextureTransform=new List<X3DTextureTransformNode>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMultiTextureTransformPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="textureTransform")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DTextureTransformNode tfn=node as X3DTextureTransformNode;
					if(tfn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else TextureTransform.Add(tfn);
				}
			}
			else return false;
			return true;
		}
	}
}
