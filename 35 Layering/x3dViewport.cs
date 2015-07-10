using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dViewport : X3DNode, X3DGroupingNode, X3DBoundedObject
	{
		public List<X3DChildNode> Children { get; set; }
		public List<double> ClipBoundary { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		bool wasClipBoundary=false;

		public x3dViewport()
		{
			Children=new List<X3DChildNode>();
			ClipBoundary=new List<double>();
			ClipBoundary.Add(0);
			ClipBoundary.Add(1);
			ClipBoundary.Add(0);
			ClipBoundary.Add(1);
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dViewportPROTO(); }

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
			else if(id=="clipBoundary")
			{
				if(wasClipBoundary) ClipBoundary.AddRange(parser.ParseSFFloatOrMFFloatValue());
				else ClipBoundary=parser.ParseSFFloatOrMFFloatValue();
				wasClipBoundary=true;
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
