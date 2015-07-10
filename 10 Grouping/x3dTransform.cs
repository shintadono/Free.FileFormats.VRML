using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Transform node is a grouping node that defines a coordinate system
	/// for its children that is relative to the coordinate systems of its ancestors.
	/// </summary>
	public class x3dTransform : X3DNode, X3DGroupingNode, IX3DCoordinateDeformerInputTransform
	{
		public SFVec3f Center { get; set; }
		public List<X3DChildNode> Children { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFRotation ScaleOrientation { get; set; }
		public SFVec3f Translation { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dTransform()
		{
			Center=new SFVec3f(0, 0, 0);
			Children=new List<X3DChildNode>();
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			ScaleOrientation=new SFRotation(0, 0, 1, 0);
			Translation=new SFVec3f(0, 0, 0);
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTransformPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="scaleOrientation") ScaleOrientation=parser.ParseSFRotationValue();
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
