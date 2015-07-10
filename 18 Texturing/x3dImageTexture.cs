using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dImageTexture : X3DNode, X3DTexture2DNode, X3DUrlObject
	{
		public List<string> URL { get; set; }
		public bool RepeatS { get; set; }
		public bool RepeatT { get; set; }
		public IX3DTexturePropertiesNode TextureProperties { get; set; }

		public x3dImageTexture()
		{
			URL=new List<string>();
			RepeatS=true;
			RepeatT=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dImageTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="repeatS") RepeatS=parser.ParseBoolValue();
			else if(id=="repeatT") RepeatT=parser.ParseBoolValue();
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
