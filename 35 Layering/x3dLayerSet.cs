using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dLayerSet : X3DNode
	{
		public int ActiveLayer { get; set; }
		public List<X3DLayerNode> Layers { get; set; }
		public List<int> Order { get; set; }

		bool wasOrder=false;

		public x3dLayerSet()
		{
			ActiveLayer=0;
			Layers=new List<X3DLayerNode>();
			Order=new List<int>();
			Order.Add(0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLayerSetPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="activeLayer") ActiveLayer=parser.ParseIntValue();
			else if(id=="layers")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DLayerNode ln=node as X3DLayerNode;
					if(ln==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Layers.Add(ln);
				}
			}
			else if(id=="order")
			{
				if(wasOrder) Order.AddRange(parser.ParseSFInt32OrMFInt32Value());
				else Order=parser.ParseSFInt32OrMFInt32Value();
				wasOrder=true;
			}
			else return false;
			return true;
		}
	}
}
