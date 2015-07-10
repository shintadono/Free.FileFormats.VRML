using System.Collections.Generic;

namespace Free.FileFormats.VRML.Fields
{
	public class MFNode : X3DArrayField
	{
		public List<SFNode> Values=new List<SFNode>();

		public MFNode() { }
		public MFNode(IEnumerable<SFNode> values) { Values=new List<SFNode>(values); }
	}
}
