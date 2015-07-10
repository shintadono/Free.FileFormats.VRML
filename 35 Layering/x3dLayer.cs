using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dLayer : X3DNode, X3DLayerNode
	{
		public List<X3DChildNode> Children { get; set; }
		public bool IsPickable { get; set; }
		public X3DViewportNode Viewport { get; set; }

		public x3dLayer()
		{
			Children=new List<X3DChildNode>();
			IsPickable=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLayerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="isPickable") IsPickable=parser.ParseBoolValue();
			else if(id=="viewport")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Viewport=node as X3DViewportNode;
					if(Viewport==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
