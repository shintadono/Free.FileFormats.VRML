using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dComposedTexture3D : X3DNode, X3DTextureNode
	{
		public List<X3DTexture2DNode> Textures { get; set; }
		public bool RepeatS { get; set; }
		public bool RepeatT { get; set; }
		public bool RepeatR { get; set; }

		public x3dComposedTexture3D()
		{
			Textures=new List<X3DTexture2DNode>();
			RepeatS=false;
			RepeatT=false;
			RepeatR=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dComposedTexture3DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="textures")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DTexture2DNode texture2DNode=node as X3DTexture2DNode;
					if(texture2DNode==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Textures.Add(texture2DNode);
				}
			}
			else if(id=="repeatS") RepeatS=parser.ParseBoolValue();
			else if(id=="repeatT") RepeatT=parser.ParseBoolValue();
			else if(id=="repeatR") RepeatR=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
