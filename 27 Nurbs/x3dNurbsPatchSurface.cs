using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Token;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NurbsPatchSurface node is a contiguous NURBS surface patch.
	/// </summary>
	public class x3dNurbsPatchSurface : X3DNode, X3DNurbsSurfaceGeometryNode
	{
		public X3DCoordinateNode ControlPoint { get; set; }
		public IX3DNurbsSurfaceGeometryNodeTexCoord TexCoord { get; set; }
		public int UTessellation { get; set; }
		public int VTessellation { get; set; }
		public List<double> Weight { get; set; }
		public bool CCW { get; set; }
		public bool Solid { get; set; }
		public bool UClosed { get; set; }
		public int UDimension { get; set; }
		public List<double> UKnot { get; set; }
		public int UOrder { get; set; }
		public bool VClosed { get; set; }
		public int VDimension { get; set; }
		public List<double> VKnot { get; set; }
		public int VOrder { get; set; }

		public x3dNurbsPatchSurface()
		{
			UTessellation=0;
			VTessellation=0;
			Weight=new List<double>();
			CCW=true;
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

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsPatchSurfacePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="controlPoint")
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
			else if(id=="texCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TexCoord=node as IX3DNurbsSurfaceGeometryNodeTexCoord;
					if(TexCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="uTessellation") UTessellation=parser.ParseIntValue();
			else if(id=="vTessellation") VTessellation=parser.ParseIntValue();
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="ccw") CCW=parser.ParseBoolValue();
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
