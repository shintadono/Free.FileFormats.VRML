using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ReceiverPdu transmits the state of radio frequency (RF) receivers
	/// modeled in the simulation.
	/// </summary>
	public class x3dReceiverPdu : X3DNode, X3DSensorNode, X3DBoundedObject
	{
		public string Address { get; set; }
		public int ApplicationID { get; set; }
		public bool Enabled { get; set; }
		public int EntityID { get; set; }
		public string MulticastRelayHost { get; set; }
		public int MulticastRelayPort { get; set; }
		public string NetworkMode { get; set; }
		public int Port { get; set; }
		public int RadioID { get; set; }
		public double ReadInterval { get; set; }
		public double ReceivedPower { get; set; }
		public int ReceiverState { get; set; }
		public bool RtpHeaderExpected { get; set; }
		public int SiteID { get; set; }
		public int TransmitterApplicationID { get; set; }
		public int TransmitterEntityID { get; set; }
		public int TransmitterRadioID { get; set; }
		public int TransmitterSiteID { get; set; }
		public int WhichGeometry { get; set; }
		public double WriteInterval { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dReceiverPdu()
		{
			Address="localhost";
			ApplicationID=1;
			Enabled=true;
			EntityID=0;
			MulticastRelayHost="";
			MulticastRelayPort=0;
			NetworkMode="standAlone";
			Port=0;
			RadioID=0;
			ReadInterval=0.1;
			ReceivedPower=0.0;
			ReceiverState=0;
			RtpHeaderExpected=false;
			SiteID=0;
			TransmitterApplicationID=1;
			TransmitterEntityID=0;
			TransmitterRadioID=0;
			TransmitterSiteID=0;
			WhichGeometry=1;
			WriteInterval=1.0;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dReceiverPduPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="address") Address=parser.ParseStringValue();
			else if(id=="applicationID") ApplicationID=parser.ParseIntValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="entityID") EntityID=parser.ParseIntValue();
			else if(id=="multicastRelayHost") MulticastRelayHost=parser.ParseStringValue();
			else if(id=="multicastRelayPort") MulticastRelayPort=parser.ParseIntValue();
			else if(id=="networkMode") NetworkMode=parser.ParseStringValue();
			else if(id=="port") Port=parser.ParseIntValue();
			else if(id=="radioID") RadioID=parser.ParseIntValue();
			else if(id=="readInterval") ReadInterval=parser.ParseDoubleValue();
			else if(id=="receivedPower") ReceivedPower=parser.ParseDoubleValue();
			else if(id=="receiverState") ReceiverState=parser.ParseIntValue();
			else if(id=="rtpHeaderExpected") RtpHeaderExpected=parser.ParseBoolValue();
			else if(id=="siteID") SiteID=parser.ParseIntValue();
			else if(id=="transmitterApplicationID") TransmitterApplicationID=parser.ParseIntValue();
			else if(id=="transmitterEntityID") TransmitterEntityID=parser.ParseIntValue();
			else if(id=="transmitterRadioID") TransmitterRadioID=parser.ParseIntValue();
			else if(id=="transmitterSiteID") TransmitterSiteID=parser.ParseIntValue();
			else if(id=="whichGeometry") WhichGeometry=parser.ParseIntValue();
			else if(id=="writeInterval") WriteInterval=parser.ParseDoubleValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
