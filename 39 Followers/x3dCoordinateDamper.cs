using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCoordinateDamper : X3DNode, X3DDamperNode<MFVec3f>
	{
		public double Tau { get; set; }
		public double Tolerance { get; set; }
		public MFVec3f InitialDestination { get; set; }
		public MFVec3f InitialValue { get; set; }
		public int Order { get; set; }

		bool wasInitialDestination=false, wasInitialValue=false;

		public x3dCoordinateDamper()
		{
			Tau=0;
			Tolerance=-1;
			Order=0;
			InitialDestination=new MFVec3f();
			InitialDestination.Values.Add(new SFVec3f(0, 0, 0));
			InitialValue=new MFVec3f();
			InitialValue.Values.Add(new SFVec3f(0, 0, 0));
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCoordinateDamperPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="tau") Tau=parser.ParseDoubleValue();
			else if(id=="tolerance") Tolerance=parser.ParseDoubleValue();
			else if(id=="order") Order=parser.ParseIntValue();
			else if(id=="initialDestination")
			{
				if(wasInitialDestination) InitialDestination.Values.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
				else InitialDestination=parser.ParseMFVec3fValue();
				wasInitialDestination=true;
			}
			else if(id=="initialValue")
			{
				if(wasInitialValue) InitialValue.Values.AddRange(parser.ParseSFVec3fOrMFVec3fValue());
				else InitialValue=parser.ParseMFVec3fValue();
				wasInitialValue=true;
			}
			else return false;
			return true;
		}
	}
}
