using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoLocation node provides the ability to geo-reference any standard X3D model.
	/// </summary>
	public class x3dGeoLocation : X3DNode, X3DGroupingNode
	{
		public List<X3DChildNode> Children { get; set; }
		public SFVec3f GeoCoords { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoLocation()
		{
			Children=new List<X3DChildNode>();
			GeoCoords=new SFVec3f(0, 0, 0);
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoLocationPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="geoCoords") GeoCoords=parser.ParseSFVec3fStringValue();
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
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
