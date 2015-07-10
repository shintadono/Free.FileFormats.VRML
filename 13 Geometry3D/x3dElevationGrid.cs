using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ElevationGrid node specifies a uniform rectangular grid of
	/// varying height in the Y=0 plane of the local coordinate system.
	/// </summary>
	public class x3dElevationGrid : X3DNode, X3DGeometryNode
	{
		public List<X3DVertexAttributeNode> Attrib { get; set; }
		public X3DColorNode Color { get; set; }
		public IX3DFogCoordinateNode FogCoord { get; set; }
		public X3DNormalNode Normal { get; set; }
		public X3DTextureCoordinateNode TexCoord { get; set; }
		public bool CCW { get; set; }
		public bool ColorPerVertex { get; set; }
		public double CreaseAngle { get; set; }
		public List<double> Height { get; set; }
		public bool NormalPerVertex { get; set; }
		public bool Solid { get; set; }
		public int XDimension { get; set; }
		public double XSpacing { get; set; }
		public int ZDimension { get; set; }
		public double ZSpacing { get; set; }

		public x3dElevationGrid()
		{
			CCW=true;
			ColorPerVertex=true;
			CreaseAngle=0;
			Height=new List<double>();
			NormalPerVertex=true;
			Solid=true;
			XDimension=0;
			XSpacing=1.0;
			ZDimension=0;
			ZSpacing=1.0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dElevationGridPROTO(); }

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
			else if(id=="fogCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					FogCoord=node as IX3DFogCoordinateNode;
					if(FogCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="normal")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Normal=node as X3DNormalNode;
					if(Normal==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="texCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TexCoord=node as X3DTextureCoordinateNode;
					if(TexCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="ccw") CCW=parser.ParseBoolValue();
			else if(id=="colorPerVertex") ColorPerVertex=parser.ParseBoolValue();
			else if(id=="creaseAngle") CreaseAngle=parser.ParseDoubleValue();
			else if(id=="height") Height.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="normalPerVertex") NormalPerVertex=parser.ParseBoolValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else if(id=="xDimension") XDimension=parser.ParseIntValue();
			else if(id=="xSpacing") XSpacing=parser.ParseDoubleValue();
			else if(id=="zDimension") ZDimension=parser.ParseIntValue();
			else if(id=="zSpacing") ZSpacing=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
