using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dImageTexture3D : X3DNode, X3DTexture3DNode, X3DUrlObject
	{
		public List<string> URL { get; set; }
		public bool RepeatS { get; set; }
		public bool RepeatT { get; set; }
		public bool RepeatR { get; set; }
		public IX3DTexturePropertiesNode TextureProperties { get; set; }

		public x3dImageTexture3D()
		{
			URL=new List<string>();
			RepeatS=false;
			RepeatT=false;
			RepeatR=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dImageTexture3DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="url") URL=parser.ParseSFStringOrMFStringValue();
			else if(id=="repeatS") RepeatS=parser.ParseBoolValue();
			else if(id=="repeatT") RepeatT=parser.ParseBoolValue();
			else if(id=="repeatR") RepeatR=parser.ParseBoolValue();
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
