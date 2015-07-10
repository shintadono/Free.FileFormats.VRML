using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTexCoordDamper2D : X3DNode, X3DDamperNode<MFVec2f>
	{
		public double Tau { get; set; }
		public double Tolerance { get; set; }
		public MFVec2f InitialDestination { get; set; }
		public MFVec2f InitialValue { get; set; }
		public int Order { get; set; }

		public x3dTexCoordDamper2D()
		{
			Tau=0;
			Tolerance=-1;
			InitialDestination=new MFVec2f();
			InitialValue=new MFVec2f();
			Order=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTexCoordDamper2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="tau") Tau=parser.ParseDoubleValue();
			else if(id=="tolerance") Tolerance=parser.ParseDoubleValue();
			else if(id=="initialDestination") InitialDestination.Values.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="initialValue") InitialValue.Values.AddRange(parser.ParseSFVec2fOrMFVec2fValue());
			else if(id=="order") Order=parser.ParseIntValue();
			else return false;
			return true;
		}
	}
}
