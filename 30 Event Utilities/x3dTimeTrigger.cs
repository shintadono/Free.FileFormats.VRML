using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// TimeTrigger is a trigger node that generates time events upon receiving Boolean events.
	/// </summary>
	public class x3dTimeTrigger : X3DNode, X3DTriggerNode
	{
		public x3dTimeTrigger()
		{
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTimeTriggerPROTO(); }
	}
}
