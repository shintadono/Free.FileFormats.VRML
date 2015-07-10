using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMultiTextureCoordinate : X3DNode, X3DTextureCoordinateNode
	{
		public List<X3DTextureCoordinateNode> TexCoord { get; set; }

		public x3dMultiTextureCoordinate()
		{
			TexCoord=new List<X3DTextureCoordinateNode>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMultiTextureCoordinatePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="texCoord"||id=="coord")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DTextureCoordinateNode tcn=node as X3DTextureCoordinateNode;
					if(tcn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else TexCoord.Add(tcn);
				}
			}
			else return false;
			return true;
		}
	}
}
