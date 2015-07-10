using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoElevationGrid node specifies a uniform grid of elevation
	/// values within some spatial reference frame.
	/// </summary>
	public class x3dGeoElevationGrid : X3DNode, X3DGeometryNode
	{
		public X3DColorNode Color { get; set; }
		public X3DNormalNode Normal { get; set; }
		public X3DTextureCoordinateNode TexCoord { get; set; }
		public double YScale { get; set; }
		public bool CCW { get; set; }
		public bool ColorPerVertex { get; set; }
		public double CreaseAngle { get; set; }
		public SFVec3f GeoGridOrigin { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }
		public List<double> Height { get; set; }
		public bool NormalPerVertex { get; set; }
		public bool Solid { get; set; }
		public int XDimension { get; set; }
		public double XSpacing { get; set; }
		public int ZDimension { get; set; }
		public double ZSpacing { get; set; }

		bool wasGeoSystem=false;
		bool wasHeight=false;

		public x3dGeoElevationGrid()
		{
			YScale=1.0;
			CCW=true;
			ColorPerVertex=true;
			CreaseAngle=0;
			GeoGridOrigin=new SFVec3f(0, 0, 0);
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
			Height=new List<double>();
			Height.Add(0);
			Height.Add(0);
			NormalPerVertex=true;
			Solid=true;
			XDimension=0;
			XSpacing=1.0;
			ZDimension=0;
			ZSpacing=1.0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoElevationGridPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="color")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Color=node as X3DColorNode;
					if(Color==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
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
			else if(id=="yScale") YScale=parser.ParseDoubleValue();
			else if(id=="ccw") CCW=parser.ParseBoolValue();
			else if(id=="colorPerVertex") ColorPerVertex=parser.ParseBoolValue();
			else if(id=="creaseAngle") CreaseAngle=parser.ParseDoubleValue();
			else if(id=="geoGridOrigin") GeoGridOrigin=parser.ParseSFVec3fStringValue();
			else if(id=="geoOrigin")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					GeoOrigin=node as IX3DGeoOriginNode;
					if(GeoOrigin==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="geoSystem")
			{
				if(wasGeoSystem) GeoSystem.AddRange(parser.ParseSFStringOrMFStringValue());
				else GeoSystem=parser.ParseSFStringOrMFStringValue();
				wasGeoSystem=true;
			}
			else if(id=="height")
			{
				if(wasHeight) Height.AddRange(parser.ParseSFFloatOrMFFloatValue());
				else Height=parser.ParseSFFloatOrMFFloatValue();
				wasHeight=true;
			}
			else if(id=="normalPerVertex") NormalPerVertex=parser.ParseBoolValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else if(id=="xDimension") XDimension=parser.ParseIntValue();
			else if(id=="xSpacing") XSpacing=parser.ParseDoubleStringValue();
			else if(id=="zDimension") ZDimension=parser.ParseIntValue();
			else if(id=="zSpacing") ZSpacing=parser.ParseDoubleStringValue();
			else return false;
			return true;
		}
	}
}
