using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoViewpoint node allows the specification of a viewpoint
	/// in terms of a geospatial coordinate.
	/// </summary>
	public class x3dGeoViewpoint : X3DNode, X3DViewpointNode
	{
		public SFVec3f CenterOfRotation { get; set; }
		public string Description { get; set; }
		public double FieldOfView { get; set; }
		public bool Headlight { get; set; }
		public bool Jump { get; set; }
		public List<string> NavType { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }
		public SFRotation Orientation { get; set; }
		public SFVec3f Position { get; set; }
		public bool RetainUserOffsets { get; set; }
		public double SpeedFactor { get; set; }

		bool wasNavType=false;
		bool wasGeoSystem=false;

		public x3dGeoViewpoint()
		{
			CenterOfRotation=new SFVec3f(0, 0, 0);
			Description="";
			FieldOfView=Math.PI/4;
			Headlight=true;
			Jump=true;
			NavType=new List<string>();
			NavType.Add("EXAMINE");
			NavType.Add("ANY");
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
			Orientation=new SFRotation(0, 0, 1, 0);
			Position=new SFVec3f(0, 0, 100000);
			RetainUserOffsets=false;
			SpeedFactor=1.0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoViewpointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="centerOfRotation") CenterOfRotation=parser.ParseSFVec3fStringValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="fieldOfView") FieldOfView=parser.ParseDoubleValue();
			else if(id=="headlight") Headlight=parser.ParseBoolValue();
			else if(id=="jump") Jump=parser.ParseBoolValue();
			else if(id=="navType")
			{
				if(wasNavType) NavType.AddRange(parser.ParseSFStringOrMFStringValue());
				else NavType=parser.ParseSFStringOrMFStringValue();
				wasNavType=true;
			}
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
			else if(id=="orientation") Orientation=parser.ParseSFRotationValue();
			else if(id=="position") Position=parser.ParseSFVec3fStringValue();
			else if(id=="retainUserOffsets") RetainUserOffsets=parser.ParseBoolValue();
			else if(id=="speedFactor") SpeedFactor=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
