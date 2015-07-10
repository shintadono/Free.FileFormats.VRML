using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// IntegerTrigger handles single field Boolean events to set an
	/// integer value for the output event.
	/// </summary>
	public class x3dIntegerTrigger : X3DNode, X3DTriggerNode
	{
		public int IntegerKey { get; set; }

		public x3dIntegerTrigger()
		{
			IntegerKey=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dIntegerTriggerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="integerKey") IntegerKey=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
