using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A DISEntityManager node notifies content when new entities
	/// arrive or current entities leave.
	/// </summary>
	public class x3dDISEntityManager : X3DNode, X3DChildNode
	{
		public string Address { get; set; }
		public int ApplicationID { get; set; }
		public List<IX3DDISEntityTypeMappingNode> Mapping { get; set; }
		public int Port { get; set; }
		public int SiteID { get; set; }

		public x3dDISEntityManager()
		{
			Address="localhost";
			ApplicationID=1;
			Mapping=new List<IX3DDISEntityTypeMappingNode>();
			Port=0;
			SiteID=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dDISEntityManagerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="address") Address=parser.ParseStringValue();
			else if(id=="applicationID") ApplicationID=parser.ParseIntValue();
			else if(id=="mapping")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DDISEntityTypeMappingNode disetm=node as IX3DDISEntityTypeMappingNode;
					if(disetm==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Mapping.Add(disetm);
				}
			}
			else if(id=="port") Port=parser.ParseIntValue();
			else if(id=="siteID") SiteID=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
