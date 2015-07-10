using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NurbsSet node groups a set of Nurbs surface nodes to a common group
	/// for rendering purposes only.
	/// </summary>
	public class x3dNurbsSet : X3DNode, X3DChildNode, X3DBoundedObject
	{
		public List<X3DNurbsSurfaceGeometryNode> Geometry { get; set; }
		public double TessellationScale { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dNurbsSet()
		{
			Geometry=new List<X3DNurbsSurfaceGeometryNode>();
			TessellationScale=0;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsSetPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="geometry")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DNurbsSurfaceGeometryNode ns=node as X3DNurbsSurfaceGeometryNode;
					if(ns==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Geometry.Add(ns);
				}
			}
			else if(id=="tessellationScale") TessellationScale=parser.ParseDoubleValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
