using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NurbsTextureCoordinate node is a NURBS surface existing in the
	/// parametric domain of its surface host specifying the mapping of the
	/// texture onto the surface.
	/// </summary>
	public class x3dNurbsTextureCoordinate : X3DNode, IX3DNurbsSurfaceGeometryNodeTexCoord
	{
		public List<SFVec2f> ControlPoint { get; set; }
		public List<double> Weight { get; set; }
		public int UDimension { get; set; }
		public List<double> UKnot { get; set; }
		public int UOrder { get; set; }
		public int VDimension { get; set; }
		public List<double> VKnot { get; set; }
		public int VOrder { get; set; }

		public x3dNurbsTextureCoordinate()
		{
			ControlPoint=new List<SFVec2f>();
			Weight=new List<double>();
			UDimension=0;
			UKnot=new List<double>();
			UOrder=3;
			VDimension=0;
			VKnot=new List<double>();
			VOrder=3;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNurbsTextureCoordinatePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="controlPoint") ControlPoint.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="weight") Weight.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="uDimension") UDimension=parser.ParseIntValue();
			else if(id=="uKnot") UKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="uOrder") UOrder=parser.ParseIntValue();
			else if(id=="vDimension") VDimension=parser.ParseIntValue();
			else if(id=="vKnot") VKnot.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="vOrder") VOrder=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
