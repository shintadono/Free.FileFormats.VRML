using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Appearance node specifies the visual properties of geometry.
	/// </summary>
	public class x3dAppearance : X3DNode, X3DAppearanceNode
	{
		public IX3DFillPropertiesNode FillProperties { get; set; }
		public IX3DLinePropertiesNode LineProperties { get; set; }
		public X3DMaterialNode Material { get; set; }
		public List<X3DShaderNode> Shaders { get; set; }
		public X3DTextureNode Texture { get; set; }
		public X3DTextureTransformNode TextureTransform { get; set; }

		public x3dAppearance()
		{
			Shaders=new List<X3DShaderNode>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dAppearancePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="fillProperties")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					FillProperties=node as IX3DFillPropertiesNode;
					if(FillProperties==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="lineProperties")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					LineProperties=node as IX3DLinePropertiesNode;
					if(LineProperties==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="material")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Material=node as X3DMaterialNode;
					if(Material==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="shaders")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DShaderNode sn=node as X3DShaderNode;
					if(sn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Shaders.Add(sn);
				}
			}
			else if(id=="texture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Texture=node as X3DTextureNode;
					if(Texture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="textureTransform")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TextureTransform=node as X3DTextureTransformNode;
					if(TextureTransform==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
