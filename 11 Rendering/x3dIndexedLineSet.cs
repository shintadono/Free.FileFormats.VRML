using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The IndexedLineSet node represents a 3D geometry formed by constructing
	/// polylines from 3D vertices specified in the coord field.
	/// </summary>
	public class x3dIndexedLineSet : X3DNode, X3DGeometryNode, IX3DLinePickSensorPickingGeometry
	{
		public List<X3DVertexAttributeNode> Attrib { get; set; }
		public X3DColorNode Color { get; set; }
		public X3DCoordinateNode Coord { get; set; }
		public IX3DFogCoordinateNode FogCoord { get; set; }
		public List<int> ColorIndex { get; set; }
		public bool ColorPerVertex { get; set; }
		public List<int> CoordIndex { get; set; }

		public x3dIndexedLineSet()
		{
			ColorIndex=new List<int>();
			ColorPerVertex=true;
			CoordIndex=new List<int>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dIndexedLineSetPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;
			
			if(id=="attrib")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DVertexAttributeNode attr=node as X3DVertexAttributeNode;
					if(attr==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Attrib.Add(attr);
				}
			}
			else if(id=="color")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Color=node as X3DColorNode;
					if(Color==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="coord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Coord=node as X3DCoordinateNode;
					if(Coord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="fogCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					FogCoord=node as IX3DFogCoordinateNode;
					if(FogCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="colorIndex") ColorIndex=parser.ParseSFInt32OrMFInt32Value();
			else if(id=="colorPerVertex") ColorPerVertex=parser.ParseBoolValue();
			else if(id=="coordIndex") CoordIndex=parser.ParseSFInt32OrMFInt32Value();
			else return false;
			return true;
		}
	}
}
