using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCoordinateDeformer : X3DNode, X3DGroupingNode
	{
		public List<X3DChildNode> Children { get; set; }
		public X3DCoordinateNode ControlPoint { get; set; }
		public List<X3DCoordinateNode> InputCoord { get; set; }
		public List<IX3DCoordinateDeformerInputTransform> InputTransform { get; set; }
		public List<X3DCoordinateNode> OutputCoord { get; set; }
		public List<double> Weight { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public int UDimension { get; set; }
		public List<double> UKnot { get; set; }
		public int UOrder { get; set; }
		public int VDimension { get; set; }
		public List<double> VKnot { get; set; }
		public int VOrder { get; set; }
		public int WDimension { get; set; }
		public List<double> WKnot { get; set; }
		public int WOrder { get; set; }

		public x3dCoordinateDeformer()
		{
			Children=new List<X3DChildNode>();
			InputCoord=new List<X3DCoordinateNode>();
			InputTransform=new List<IX3DCoordinateDeformerInputTransform>();
			OutputCoord=new List<X3DCoordinateNode>();
			Weight=new List<double>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
			UDimension=0;
			UKnot=new List<double>();
			UOrder=2;
			VDimension=0;
			VKnot=new List<double>();
			VOrder=2;
			WDimension=0;
			WKnot=new List<double>();
			WOrder=2;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCoordinateDeformerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DShapeNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="controlPoint")
			{
				object token=parser.PeekNextToken();
				if(token is VRMLTokenIdKeywordOrFieldType)
				{
					X3DNode node=parser.ParseSFNodeValue();
					if(node!=null)
					{
						ControlPoint=node as X3DCoordinateNode;
						if(ControlPoint==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					}
				}
				else
				{
					x3dCoordinate coords=new x3dCoordinate();
					coords.Point=parser.ParseSFVec3fOrMFVec3fValue();
					ControlPoint=coords;
				}
			}
			else if(id=="inputCoord")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DCoordinateNode coord=node as X3DCoordinateNode;
					if(coord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else InputCoord.Add(coord);
				}
			}
			else if(id=="inputTransform")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DCoordinateDeformerInputTransform transf=node as IX3DCoordinateDeformerInputTransform;
					if(transf==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else InputTransform.Add(transf);
				}
			}
			else if(id=="outputCoord")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DCoordinateNode coord=node as X3DCoordinateNode;
					if(coord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else OutputCoord.Add(coord);
				}
			}
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else if(id=="uDimension") UDimension=parser.ParseIntValue();
			else if(id=="uKnot") UKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="uOrder") UOrder=parser.ParseIntValue();
			else if(id=="vDimension") VDimension=parser.ParseIntValue();
			else if(id=="vKnot") VKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="vOrder") VOrder=parser.ParseIntValue();
			else if(id=="wDimension") WDimension=parser.ParseIntValue();
			else if(id=="wKnot") WKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="wOrder") WOrder=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
