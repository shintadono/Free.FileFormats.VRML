using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoMetadata node supports the specification of metadata
	/// describing any number of geospatial nodes.
	/// </summary>
	public class x3dGeoMetadata : X3DNode, X3DInfoNode
	{
		public List<X3DNode> Data { get; set; }
		public List<string> Summary { get; set; }
		public List<string> URL { get; set; }

		public x3dGeoMetadata()
		{
			Data=new List<X3DNode>();
			Summary=new List<string>();
			URL=new List<string>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoMetadataPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="data") Data.AddRange(parser.ParseSFNodeOrMFNodeValue());
			else if(id=="summary") Summary.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else return false;
			return true;
		}
	}
}
