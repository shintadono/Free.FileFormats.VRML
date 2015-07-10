using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The LineProperties node specifies additional properties to be applied to all line geometry.
	/// </summary>
	public class x3dLineProperties : X3DNode, X3DAppearanceChildNode, IX3DLinePropertiesNode
	{
		public bool Applied { get; set; }
		public int Linetype { get; set; }
		public double LinewidthScaleFactor { get; set; }

		public x3dLineProperties()
		{
			Applied=true;
			Linetype=1;
			LinewidthScaleFactor=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLinePropertiesPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="applied") Applied=parser.ParseBoolValue();
			else if(id=="linetype") Linetype=parser.ParseIntValue();
			else if(id=="linewidthScaleFactor") LinewidthScaleFactor=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
