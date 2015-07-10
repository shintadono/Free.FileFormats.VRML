using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// Applications may need to alter the shape of individual segments.
	/// </summary>
	public class x3dHAnimDisplacer : X3DNode, X3DGeometricPropertyNode, IX3DHAnimDisplacerNode
	{
		public List<int> CoordIndex { get; set; }
		public List<SFVec3f> Displacements { get; set; }
		public string Name { get; set; }
		public double Weight { get; set; }

		public x3dHAnimDisplacer()
		{
			CoordIndex=new List<int>();
			Displacements=new List<SFVec3f>();
			Name="";
			Weight=0.0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dHAnimDisplacerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="coordIndex") CoordIndex.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="displacements") Displacements.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
			else if(id=="name") Name=parser.ParseStringValue();
			else if(id=="weight") Weight=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
