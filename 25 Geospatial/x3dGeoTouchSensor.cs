using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A GeoTouchSensor node tracks the location and state of a pointing
	/// device and detects when the user points at geometry contained by
	/// the parent group of the GeoTouchSensor.
	/// </summary>
	public class x3dGeoTouchSensor : X3DNode, X3DTouchSensorNode
	{
		public string Description { get; set; }
		public bool Enabled { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoTouchSensor()
		{
			Description="";
			Enabled=true;
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoTouchSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="description") Description=parser.ParseStringValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
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
