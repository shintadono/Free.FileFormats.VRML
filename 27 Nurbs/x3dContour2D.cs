using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Contour2D node groups a set of curve segments to a composite contour
	/// </summary>
	public class x3dContour2D : X3DNode, IX3DContour2DNode
	{
		public List<IX3DContour2DChildren> Children { get; set; }

		public x3dContour2D()
		{
			Children=new List<IX3DContour2DChildren>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dContour2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DContour2DChildren child=node as IX3DContour2DChildren;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else return false;
			return true;
		}
	}
}
