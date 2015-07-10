using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The TransformSensor node generates events when its target object enters,
	/// exits, and moves within a region in space (defined by a box).
	/// </summary>
	public class x3dTransformSensor : X3DNode, X3DEnvironmentalSensorNode
	{
		public SFVec3f Center { get; set; }
		public bool Enabled { get; set; }
		public SFVec3f Size { get; set; }
		public IX3DTranformSensorTargetObject TargetObject { get; set; }

		public x3dTransformSensor()
		{
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTransformSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="size") Size=parser.ParseSFVec3fValue();
			else if(id=="targetObject")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TargetObject=node as IX3DTranformSensorTargetObject;
					if(TargetObject==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
