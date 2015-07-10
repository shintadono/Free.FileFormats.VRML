using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The PlaneSensor node maps pointing device motion into two-dimensional
	/// translation in a plane parallel to the Z=0 plane of the local sensor
	/// coordinate system.
	/// </summary>
	public class x3dPlaneSensor : X3DNode, X3DDragSensorNode
	{
		public bool AutoOffset { get; set; }
		public SFRotation AxisRotation { get; set; }
		public string Description { get; set; }
		public bool Enabled { get; set; }
		public SFVec2f MaxPosition { get; set; }
		public SFVec2f MinPosition { get; set; }
		public SFVec3f Offset { get; set; }

		public x3dPlaneSensor()
		{
			AutoOffset=true;
			AxisRotation=new SFRotation(0, 0, 1, 0);
			Description="";
			Enabled=true;
			MaxPosition=new SFVec2f(-1, -1);
			MinPosition=new SFVec2f(0, 0);
			Offset=new SFVec3f(0, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPixelTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="autoOffset") AutoOffset=parser.ParseBoolValue();
			else if(id=="axisRotation") AxisRotation=parser.ParseSFRotationValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="maxPosition") MaxPosition=parser.ParseSFVec2fValue();
			else if(id=="minPosition") MinPosition=parser.ParseSFVec2fValue();
			else if(id=="offset") Offset=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
