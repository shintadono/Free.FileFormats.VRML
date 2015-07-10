using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The LOD node specifies various levels of detail or complexity for a
	/// given object, and provides hints allowing browsers to automatically
	/// choose the appropriate version of the object based on the distance
	/// from the user.
	/// </summary>
	public class x3dLOD : X3DNode, X3DGroupingNode, IX3DCADFaceShape
	{
		public List<X3DChildNode> Children { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public SFVec3f Center { get; set; }
		public bool ForceTransitions { get; set; }
		public List<double> Range { get; set; }

		public List<X3DChildNode> Level { get { return Children; } set { Children=value; } }

		public x3dLOD()
		{
			Children=new List<X3DChildNode>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
			Center=new SFVec3f(0, 0, 0);
			ForceTransitions=false;
			Range=new List<double>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLODPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children"||id=="level"||id=="levels")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="forceTransitions") ForceTransitions=parser.ParseBoolValue();
			else if(id=="range") Range=parser.ParseSFFloatOrMFFloatValue();
			else return false;
			return true;
		}
	}
}
