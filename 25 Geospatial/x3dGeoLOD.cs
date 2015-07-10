using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The GeoLOD node provides a terrain-specialized form of the LOD node.
	/// </summary>
	public class x3dGeoLOD : X3DNode, X3DChildNode, X3DBoundedObject
	{
		public SFVec3f Center { get; set; }
		public List<string> Child1URL { get; set; }
		public List<string> Child2URL { get; set; }
		public List<string> Child3URL { get; set; }
		public List<string> Child4URL { get; set; }
		public IX3DGeoOriginNode GeoOrigin { get; set; }
		public List<string> GeoSystem { get; set; }
		public double Range { get; set; }
		public List<string> RootURL { get; set; }
		public List<X3DChildNode> RootNode { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		bool wasGeoSystem=false;

		public x3dGeoLOD()
		{
			Center=new SFVec3f(0, 0, 0);
			Child1URL=new List<string>();
			Child2URL=new List<string>();
			Child3URL=new List<string>();
			Child4URL=new List<string>();
			GeoSystem=new List<string>();
			GeoSystem.Add("GD");
			GeoSystem.Add("WE");
			Range=10;
			RootURL=new List<string>();
			RootNode=new List<X3DChildNode>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dGeoLODPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fStringValue();
			else if(id=="child1Url") Child1URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="child2Url") Child2URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="child3Url") Child3URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="child4Url") Child4URL.AddRange(parser.ParseSFStringOrMFStringValue());
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
			else if(id=="range") Range=parser.ParseDoubleValue();
			else if(id=="rootUrl") RootURL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="rootNode")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode rn=node as X3DChildNode;
					if(rn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else RootNode.Add(rn);
				}
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
