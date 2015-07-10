using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dScalarChaser : X3DNode, X3DChaserNode<SFFloat>
	{
		public double Duration { get; set; }
		public SFFloat InitialDestination { get; set; }
		public SFFloat InitialValue { get; set; }

		public x3dScalarChaser()
		{
			Duration=0;
			InitialDestination=new SFFloat(0);
			InitialValue=new SFFloat(0);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dScalarChaserPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="duration") Duration=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFFloatValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFFloatValue();
			else return false;
			return true;
		}
	}
}
