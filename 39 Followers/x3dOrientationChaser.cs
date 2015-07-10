using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dOrientationChaser : X3DNode, X3DChaserNode<SFRotation>
	{
		public double Duration { get; set; }
		public SFRotation InitialDestination { get; set; }
		public SFRotation InitialValue { get; set; }

		public x3dOrientationChaser()
		{
			Duration=0;
			InitialDestination=new SFRotation(0, 1, 0, 0);
			InitialValue=new SFRotation(0, 1, 0, 0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dOrientationChaserPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="duration") Duration=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFRotationValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFRotationValue();
			else return false;
			return true;
		}
	}
}
