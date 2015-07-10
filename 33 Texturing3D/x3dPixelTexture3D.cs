using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPixelTexture3D : X3DNode, X3DTexture3DNode
	{
		public List<int> Image { get; set; }
		public bool RepeatS { get; set; }
		public bool RepeatR { get; set; }
		public bool RepeatT { get; set; }
		public IX3DTexturePropertiesNode TextureProperties { get; set; }

		public x3dPixelTexture3D()
		{
			Image=new List<int>();
			RepeatS=false;
			RepeatR=false;
			RepeatT=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPixelTexture3DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="image") Image=parser.ParseSFInt32OrMFInt32Value();
			else if(id=="repeatS") RepeatS=parser.ParseBoolValue();
			else if(id=="repeatR") RepeatR=parser.ParseBoolValue();
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

	public class x3dPixel3DTexture : x3dPixelTexture3D
	{
		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="image")
			{
				try
				{
					Image.Clear();
					Image.Add(parser.ParseIntValue()); // Number of Components
					Image.Add(parser.ParseIntValue()); // Width
					Image.Add(parser.ParseIntValue()); // Height
					Image.Add(parser.ParseIntValue()); // Depth
				}
				catch(UserCancellationException) { throw; }
				catch(Exception ex)
				{
					parser.ErrorParsingNode(VRMLReaderError.SFImageInvalid, ex, this, id, null, line);
				}

				if(Image[1]<0||Image[2]<0||Image[3]<0||Image[0]<0||Image[0]>4)
					parser.ErrorParsingNode(VRMLReaderError.SFImageInvalid, this, id, null, line);

				if(!(Image[0]==0||Image[1]==0||Image[2]==0||Image[3]==0))
				{
					int count=Image[1]*Image[2]*Image[3];
					try
					{
						for(int i=0; i<count; i++) Image.Add(parser.ParseIntValue());
					}
					catch(UserCancellationException) { throw; }
					catch(Exception ex)
					{
						parser.ErrorParsingNode(VRMLReaderError.SFImageInvalid, ex, this, id, null, parser.Line);
					}
				}
			}
			else if(id=="repeatS") RepeatS=parser.ParseBoolValue();
			else if(id=="repeatR") RepeatR=parser.ParseBoolValue();
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
