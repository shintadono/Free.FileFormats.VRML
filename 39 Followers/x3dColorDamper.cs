using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dColorDamper : X3DNode, X3DDamperNode<SFColor>
	{
		public double Tau { get; set; }
		public double Tolerance { get; set; }
		public SFColor InitialDestination { get; set; }
		public SFColor InitialValue { get; set; }
		public int Order { get; set; }

		public x3dColorDamper()
		{
			Tau=0;
			Tolerance=-1;
			InitialDestination=new SFColor(0.8, 0.8, 0.8);
			InitialValue=new SFColor(0.8, 0.8, 0.8);
			Order=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dColorDamperPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="tau") Tau=parser.ParseDoubleValue();
			else if(id=="tolerance") Tolerance=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFColorValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFColorValue();
			else if(id=="order") Order=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
