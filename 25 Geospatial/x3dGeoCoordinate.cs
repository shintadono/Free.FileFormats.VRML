using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoCoordinate node specifies a list of coordinates in a spatial reference frame.
	/// </summary>
	public class x3dGeoCoordinate : X3DNode, X3DCoordinateNode
	{
		public List<SFVec3f> Point { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoCoordinate()
		{
			Point=new List<SFVec3f>();
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoCoordinatePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="point") Point.AddRange(parser.ParseGeoCoordinatePointValue());
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
			else return false;
			return true;
		}
	}
}
