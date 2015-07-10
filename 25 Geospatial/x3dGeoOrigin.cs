using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoOrigin node defines an absolute geospatial location and an
	/// implicit local coordinate frame against which geometry is referenced.
	/// </summary>
	public class x3dGeoOrigin : X3DNode, IX3DGeoOriginNode
	{
		public SFVec3f GeoCoords { get; set; }
		public List<string> GeoSystem { get; set; }
		public bool RotateYUp { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoOrigin()
		{
			GeoCoords=new SFVec3f(0, 0, 0);
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
			RotateYUp=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoOriginPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="geoCoords") GeoCoords=parser.ParseSFVec3fStringValue();
			else if(id=="geoSystem")
			{
				if(wasGeoSystem) GeoSystem.AddRange(parser.ParseSFStringOrMFStringValue());
				else GeoSystem=parser.ParseSFStringOrMFStringValue();
				wasGeoSystem=true;
			}
			else if(id=="rotateYUp") RotateYUp=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
