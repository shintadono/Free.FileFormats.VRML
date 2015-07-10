using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A TouchSensor node tracks the location and state of the pointing
	/// device and detects when the user points at geometry contained by
	/// the TouchSensor node's parent group.
	/// </summary>
	public class x3dTouchSensor : X3DNode, X3DTouchSensorNode
	{
		public string Description { get; set; }
		public bool Enabled { get; set; }

		public x3dTouchSensor()
		{
			Enabled=true;
			Description="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTouchSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
