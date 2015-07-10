using System;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The CylinderSensor node maps pointer motion (e.g., a mouse or wand)
	/// into a rotation on an invisible cylinder that is aligned with the Y-axis
	/// of the local sensor coordinate system.
	/// </summary>
	public class x3dCylinderSensor : X3DNode, X3DDragSensorNode
	{
		public bool AutoOffset { get; set; }
		public SFRotation AxisRotation { get; set; }
		public string Description { get; set; }
		public double DiskAngle { get; set; }
		public bool Enabled { get; set; }
		public double MaxAngle { get; set; }
		public double MinAngle { get; set; }
		public double Offset { get; set; }

		public x3dCylinderSensor()
		{
			AutoOffset=true;
			AxisRotation=new SFRotation(0, 1, 0, 0);
			Description="";
			DiskAngle=Math.PI/12;
			Enabled=true;
			MaxAngle=-1;
			MinAngle=0;
			Offset=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCylinderSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="autoOffset") AutoOffset=parser.ParseBoolValue();
			else if(id=="axisRotation") AxisRotation=parser.ParseSFRotationValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="diskAngle") DiskAngle=parser.ParseDoubleValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="maxAngle") MaxAngle=parser.ParseDoubleValue();
			else if(id=="minAngle") MinAngle=parser.ParseDoubleValue();
			else if(id=="offset") Offset=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
