using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoPositionInterpolator node provides an interpolator capability
	/// where key values are specified in geographic coordinates and the
	/// interpolation is performed within the specified spatial reference frame.
	/// </summary>
	public class x3dGeoPositionInterpolator : X3DNode, X3DInterpolatorNode<SFVec3f>
	{
		public List<double> Key { get; set; }
		public List<SFVec3f> KeyValue { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoPositionInterpolator()
		{
			Key=new List<double>();
			KeyValue=new List<SFVec3f>();
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoPositionInterpolatorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="key") Key.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="keyValue") KeyValue.AddRange(parser.ParseSFVec3fStringOrMFVec3fStringsValue());
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
