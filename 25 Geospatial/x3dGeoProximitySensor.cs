using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoProximitySensor node generates events when the viewer enters,
	/// exits, and moves within a region in space (defined by a box).
	/// </summary>
	public class x3dGeoProximitySensor : X3DNode, X3DEnvironmentalSensorNode
	{
		public bool Enabled { get; set; }
		public SFVec3f GeoCenter { get { return Center; } set { Center=value; } }
		public SFVec3f Size { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }

		// 'inherited' from X3DEnvironmentalSensorNode
		public SFVec3f Center { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoProximitySensor()
		{
			Enabled=true;
			GeoCenter=new SFVec3f(0, 0, 0);
			Size=new SFVec3f(0, 0, 0);
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoProximitySensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="geoCenter") GeoCenter=parser.ParseSFVec3fValue();
			else if(id=="size") Size=parser.ParseSFVec3fValue();
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
