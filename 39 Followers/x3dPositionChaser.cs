using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPositionChaser : X3DNode, X3DChaserNode<SFVec3f>
	{
		public double Duration { get; set; }
		public SFVec3f InitialDestination { get; set; }
		public SFVec3f InitialValue { get; set; }

		public x3dPositionChaser()
		{
			Duration=0;
			InitialDestination=new SFVec3f(0, 0, 0);
			InitialValue=new SFVec3f(0, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPositionChaserPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="duration") Duration=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFVec3fValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
