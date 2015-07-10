using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dLayoutLayer : X3DNode, X3DLayerNode
	{
		public List<X3DChildNode> Children { get; set; }
		public bool IsPickable { get; set; }
		public X3DLayoutNode Layout { get; set; }
		public X3DViewportNode Viewport { get; set; }

		public x3dLayoutLayer()
		{
			Children=new List<X3DChildNode>();
			IsPickable=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLayoutLayerPROTO(); }

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
			else if(id=="layout")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Layout=node as X3DLayoutNode;
					if(Layout==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
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
