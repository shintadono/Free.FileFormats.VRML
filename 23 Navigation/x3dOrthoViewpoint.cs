using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The OrthoViewpoint node defines a viewpoint that provides an
	/// orthographic view of the scene.
	/// </summary>
	public class x3dOrthoViewpoint : X3DNode, X3DViewpointNode
	{
		public SFVec3f CenterOfRotation { get; set; }
		public string Description { get; set; }
		public List<double> FieldOfView { get; set; }
		public bool Jump { get; set; }
		public SFRotation Orientation { get; set; }
		public SFVec3f Position { get; set; }
		public bool RetainUserOffsets { get; set; }

		bool wasFieldOfView=false;

		public x3dOrthoViewpoint()
		{
			CenterOfRotation=new SFVec3f(0, 0, 0);
			Description="";
			FieldOfView=new List<double>();
			FieldOfView.Add(-1);
			FieldOfView.Add(-1);
			FieldOfView.Add(1);
			FieldOfView.Add(1);
			Jump=true;
			Orientation=new SFRotation(0, 0, 1, 0);
			Position=new SFVec3f(0, 0, 10);
			RetainUserOffsets=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dOrthoViewpointPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="centerOfRotation") CenterOfRotation=parser.ParseSFVec3fValue();
			else if(id=="description") Description=parser.ParseStringValue();
			else if(id=="fieldOfView")
			{
				if(wasFieldOfView) FieldOfView.AddRange(parser.ParseSFFloatOrMFFloatValue());
				else FieldOfView=parser.ParseSFFloatOrMFFloatValue();
				wasFieldOfView=true;
			}
			else if(id=="jump") Jump=parser.ParseBoolValue();
			else if(id=="orientation") Orientation=parser.ParseSFRotationValue();
			else if(id=="position") Position=parser.ParseSFVec3fValue();
			else if(id=="retainUserOffsets") RetainUserOffsets=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
