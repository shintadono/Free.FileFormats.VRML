using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The HAnimSegment node is a grouping node that will typically contain
	/// either a number of Shape nodes or perhaps Transform nodes that
	/// position the body part.
	/// </summary>
	public class x3dHAnimSegment : X3DNode, X3DGroupingNode, IX3DHAnimJointChildren, IX3DHAnimeSegmentNode
	{
		public SFVec3f CenterOfMass { get; set; }
		public List<X3DChildNode> Children { get; set; }
		public X3DCoordinateNode Coord { get; set; }
		public List<IX3DHAnimDisplacerNode> Displacers { get; set; }
		public double Mass { get; set; }
		public List<double> MomentsOfInertia { get; set; }
		public string Name { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		bool wasMomentsOfInertia=false;

		public x3dHAnimSegment()
		{
			CenterOfMass=new SFVec3f(0, 0, 0);
			Children=new List<X3DChildNode>();
			Displacers=new List<IX3DHAnimDisplacerNode>();
			Mass=0;
			MomentsOfInertia=new List<double>(new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
			Name="";
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dHAnimSegmentPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="centerOfMass") CenterOfMass=parser.ParseSFVec3fValue();
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
			else if(id=="coord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Coord=node as X3DCoordinateNode;
					if(Coord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="displacers")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DHAnimDisplacerNode displacer=node as IX3DHAnimDisplacerNode;
					if(displacer==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Displacers.Add(displacer);
				}
			}
			else if(id=="mass") Mass=parser.ParseDoubleValue();
			else if(id=="momentsOfInertia")
			{
				if(wasMomentsOfInertia) MomentsOfInertia.AddRange(parser.ParseSFFloatOrMFFloatValue());
				else MomentsOfInertia=parser.ParseSFFloatOrMFFloatValue();
				wasMomentsOfInertia=true;
			}
			else if(id=="name") Name=parser.ParseStringValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
