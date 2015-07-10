using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPositionDamper2D : X3DNode, X3DDamperNode<SFVec2f>
	{
		public double Tau { get; set; }
		public double Tolerance { get; set; }
		public SFVec2f InitialDestination { get; set; }
		public SFVec2f InitialValue { get; set; }
		public int Order { get; set; }

		public x3dPositionDamper2D()
		{
			Tau=0;
			Tolerance=-1;
			InitialDestination=new SFVec2f(0, 0);
			InitialValue=new SFVec2f(0, 0);
			Order=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPositionDamper2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="tau") Tau=parser.ParseDoubleValue();
			else if(id=="tolerance") Tolerance=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination=parser.ParseSFVec2fValue();
			else if(id=="initialValue") InitialValue=parser.ParseSFVec2fValue();
			else if(id=="order") Order=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
