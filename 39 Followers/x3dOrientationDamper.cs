using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dOrientationDamper : X3DNode, X3DDamperNode<SFRotation>
	{
		public double Tau { get; set; }
		public double Tolerance { get; set; }
		public SFRotation InitialDestination { get; set; }
		public SFRotation InitialValue { get; set; }
		public int Order { get; set; }

		public x3dOrientationDamper()
		{
			Tau=0;
			Tolerance=-1;
			InitialDestination=new SFRotation(0, 1, 0, 0);
			InitialValue=new SFRotation(0, 1, 0, 0);
			Order=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dOrientationDamperPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="tau") Tau=parser.ParseDoubleValue();
			else if(id=="tolerance") Tolerance=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFRotationValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFRotationValue();
			else if(id=="order") Order=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
