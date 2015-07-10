using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPositionChaser2D : X3DNode, X3DChaserNode<SFVec2f>
	{
		public double Duration { get; set; }
		public SFVec2f InitialDestination { get; set; }
		public SFVec2f InitialValue { get; set; }

		public x3dPositionChaser2D()
		{
			Duration=0;
			InitialDestination=new SFVec2f(0, 0);
			InitialValue=new SFVec2f(0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPositionChaser2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="duration") Duration=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFVec2fValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFVec2fValue();
			else return false;
			return true;
		}
	}
}
