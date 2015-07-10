using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The SphereSensor node maps pointing device motion into spherical
	/// rotation about the origin of the local coordinate system.
	/// </summary>
	public class x3dSphereSensor : X3DNode, X3DDragSensorNode
	{
		public bool AutoOffset { get; set; }
		public string Description { get; set; }
		public bool Enabled { get; set; }
		public SFRotation Offset { get; set; }

		public x3dSphereSensor()
		{
			AutoOffset=true;
			Description="";
			Enabled=true;
			Offset=new SFRotation(0, 1, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSphereSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="autoOffset") AutoOffset=parser.ParseBoolValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="offset") Offset=parser.ParseSFRotationValue();
			else return false;
			return true;
		}
	}
}
