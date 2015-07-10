using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The metadata provided by this node is contained in the Boolean
	/// values of the value field.
	/// 
	/// Implementation supports x3dMetadata*-nodes to be stored in children
	/// arrays, even if not standard.
	/// </summary>
	public class x3dMetadataBoolean : X3DNode, X3DChildNode, X3DMetadataObject
	{
		public string Name { get; set; }
		public string Reference { get; set; }
		public List<bool> Value { get; set; }

		public x3dMetadataBoolean()
		{
			Name="";
			Reference="";
			Value=new List<bool>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMetadataBooleanPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="name") Name=parser.ParseStringValue();
			else if(id=="reference") Reference=parser.ParseStringValue();
			else if(id=="value") Value.AddRange(parser.ParseSFBoolOrMFBoolValue());
			else return false;
			return true;
		}
	}
}
