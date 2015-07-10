using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoTransform node is a grouping node that defines a coordinate
	/// system for its children allow for the translation and orientation
	/// of geometry built using GeoCoordinate nodes within the local world
	/// coordinate system.
	/// </summary>
	public class x3dGeoTransform : X3DNode, X3DGroupingNode
	{
		public List<X3DChildNode> Children { get; set; }
		public SFVec3f GeoCenter { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFRotation ScaleOrientation { get; set; }
		public SFVec3f Translation { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoTransform()
		{
			Children=new List<X3DChildNode>();
			GeoCenter=new SFVec3f(0, 0, 0);
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			ScaleOrientation=new SFRotation(0, 0, 1, 0);
			Translation=new SFVec3f(0, 0, 0);
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoTransformPROTO(); }

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
			else if(id=="geoCenter") GeoCenter=parser.ParseSFVec3fValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="scaleOrientation") ScaleOrientation=parser.ParseSFRotationValue();
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
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
