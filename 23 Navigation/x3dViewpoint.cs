using System;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Viewpoint node defines a viewpoint that provides a perspective view of the scene.
	/// </summary>
	public class x3dViewpoint : X3DNode, X3DViewpointNode
	{
		public SFVec3f CenterOfRotation { get; set; }
		public string Description { get; set; }
		public double FieldOfView { get; set; }
		public bool Jump { get; set; }
		public SFRotation Orientation { get; set; }
		public SFVec3f Position { get; set; }
		public bool RetainUserOffsets { get; set; }

		public x3dViewpoint()
		{
			CenterOfRotation=new SFVec3f(0, 0, 0);
			Description="";
			FieldOfView=Math.PI/4;
			Jump=true;
			Orientation=new SFRotation(0, 0, 1, 0);
			Position=new SFVec3f(0, 0, 10);
			RetainUserOffsets=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dViewpointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="centerOfRotation") CenterOfRotation=parser.ParseSFVec3fValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="fieldOfView") FieldOfView=parser.ParseDoubleValue();
			else if(id=="jump") Jump=parser.ParseBoolValue();
			else if(id=="orientation") Orientation=parser.ParseSFRotationValue();
			else if(id=="position") Position=parser.ParseSFVec3fValue();
			else if(id=="retainUserOffsets") RetainUserOffsets=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
