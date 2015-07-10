using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Inline node embeds an X3D scene stored at a location on the World
	/// Wide Web into the current scene.
	/// </summary>
	public class x3dInline : X3DNode, X3DChildNode, X3DBoundedObject, X3DUrlObject, IX3DPickSensorNodePickTarget
	{
		public bool Load { get; set; }
		public List<string> URL { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dInline()
		{
			Load=true;
			URL=new List<string>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dInlinePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="load") Load=parser.ParseBoolValue();
			else if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
