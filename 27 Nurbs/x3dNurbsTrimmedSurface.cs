using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NurbsTrimmedSurface node defines a NURBS surface that is trimmed by a set of trimming loops.
	/// </summary>
	public class x3dNurbsTrimmedSurface : X3DNode, X3DNurbsSurfaceGeometryNode
	{
		public X3DCoordinateNode ControlPoint { get; set; }
		public IX3DNurbsSurfaceGeometryNodeTexCoord TexCoord { get; set; }
		public List<IX3DContour2DNode> TrimmingContour { get; set; }
		public int UTessellation { get; set; }
		public int VTessellation { get; set; }
		public List<double> Weight { get; set; }
		public bool Solid { get; set; }
		public bool UClosed { get; set; }
		public int UDimension { get; set; }
		public List<double> UKnot { get; set; }
		public int UOrder { get; set; }
		public bool VClosed { get; set; }
		public int VDimension { get; set; }
		public List<double> VKnot { get; set; }
		public int VOrder { get; set; }

		public x3dNurbsTrimmedSurface()
		{
			TrimmingContour=new List<IX3DContour2DNode>();
			UTessellation=0;
			VTessellation=0;
			Weight=new List<double>();
			Solid=true;
			UClosed=false;
			UDimension=0;
			UKnot=new List<double>();
			UOrder=3;
			VClosed=false;
			VDimension=0;
			VKnot=new List<double>();
			VOrder=3;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsTrimmedSurfacePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="controlPoint")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					ControlPoint=node as X3DCoordinateNode;
					if(ControlPoint==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="texCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TexCoord=node as IX3DNurbsSurfaceGeometryNodeTexCoord;
					if(TexCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="trimmingContour")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DContour2DNode contour=node as IX3DContour2DNode;
					if(contour==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else TrimmingContour.Add(contour);
				}
			}
			else if(id=="uTessellation") UTessellation=parser.ParseIntValue();
			else if(id=="vTessellation") VTessellation=parser.ParseIntValue();
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else if(id=="uClosed") UClosed=parser.ParseBoolValue();
			else if(id=="uDimension") UDimension=parser.ParseIntValue();
			else if(id=="uKnot") UKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="uOrder") UOrder=parser.ParseIntValue();
			else if(id=="vClosed") VClosed=parser.ParseBoolValue();
			else if(id=="vDimension") VDimension=parser.ParseIntValue();
			else if(id=="vKnot") VKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="vOrder") VOrder=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
