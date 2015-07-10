using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// BooleanToggle stores a Boolean value for toggling on/off.
	/// </summary>
	public class x3dBooleanToggle : X3DNode, X3DChildNode
	{
		public bool Toggle { get; set; }

		public x3dBooleanToggle()
		{
			Toggle=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBooleanTogglePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="toggle") Toggle=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
