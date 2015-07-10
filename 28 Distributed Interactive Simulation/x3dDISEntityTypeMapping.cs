using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A DISEntityTypeMapping node provides a mapping from DIS Entity type
	/// information to an X3D model.
	/// </summary>
	public class x3dDISEntityTypeMapping : X3DNode, X3DInfoNode, X3DUrlObject, IX3DDISEntityTypeMappingNode
	{
		public List<string> URL { get; set; }
		public int Category { get; set; }
		public int Country { get; set; }
		public int Domain { get; set; }
		public int Extra { get; set; }
		public int Kind { get; set; }
		public int Specific { get; set; }
		public int Subcategory { get; set; }

		public x3dDISEntityTypeMapping()
		{
			URL=new List<string>();
			Category=0;
			Country=0;
			Domain=0;
			Extra=0;
			Kind=0;
			Specific=0;
			Subcategory=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dDISEntityTypeMappingPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="category") Category=parser.ParseIntValue();
			else if(id=="country") Country=parser.ParseIntValue();
			else if(id=="domain") Domain=parser.ParseIntValue();
			else if(id=="extra") Extra=parser.ParseIntValue();
			else if(id=="kind") Kind=parser.ParseIntValue();
			else if(id=="specific") Specific=parser.ParseIntValue();
			else if(id=="subcategory") Subcategory=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
