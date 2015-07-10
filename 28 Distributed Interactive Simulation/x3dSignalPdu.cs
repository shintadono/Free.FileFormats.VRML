using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// Transmission of voice, audio or other data is communicated by
	/// issuing a Signal PDU from the SignalPdu node.
	/// </summary>
	public class x3dSignalPdu : X3DNode, X3DSensorNode, X3DBoundedObject
	{
		public string Address { get; set; }
		public int ApplicationID { get; set; }
		public List<int> Data { get; set; }
		public int DataLength { get; set; }
		public bool Enabled { get; set; }
		public int EncodingScheme { get; set; }
		public int EntityID { get; set; }
		public string MulticastRelayHost { get; set; }
		public int MulticastRelayPort { get; set; }
		public string NetworkMode { get; set; }
		public int Port { get; set; }
		public int RadioID { get; set; }
		public double ReadInterval { get; set; }
		public bool RtpHeaderExpected { get; set; }
		public int SampleRate { get; set; }
		public int Samples { get; set; }
		public int SiteID { get; set; }
		public int TdlType { get; set; }
		public int WhichGeometry { get; set; }
		public double WriteInterval { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dSignalPdu()
		{
			Address="localhost";
			ApplicationID=1;
			Data=new List<int>();
			DataLength=0;
			Enabled=true;
			EncodingScheme=0;
			EntityID=0;
			MulticastRelayHost="";
			MulticastRelayPort=0;
			NetworkMode="standAlone";
			Port=0;
			RadioID=0;
			ReadInterval=0.1;
			RtpHeaderExpected=false;
			SampleRate=0;
			Samples=0;
			SiteID=0;
			TdlType=0;
			WhichGeometry=1;
			WriteInterval=1.0;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSignalPduPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="address") Address=parser.ParseStringValue();
			else if(id=="applicationID") ApplicationID=parser.ParseIntValue();
			else if(id=="data") Data.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="dataLength") DataLength=parser.ParseIntValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="encodingScheme") EncodingScheme=parser.ParseIntValue();
			else if(id=="entityID") EntityID=parser.ParseIntValue();
			else if(id=="multicastRelayHost") MulticastRelayHost=parser.ParseStringValue();
			else if(id=="multicastRelayPort") MulticastRelayPort=parser.ParseIntValue();
			else if(id=="networkMode") NetworkMode=parser.ParseStringValue();
			else if(id=="port") Port=parser.ParseIntValue();
			else if(id=="radioID") RadioID=parser.ParseIntValue();
			else if(id=="readInterval") ReadInterval=parser.ParseDoubleValue();
			else if(id=="rtpHeaderExpected") RtpHeaderExpected=parser.ParseBoolValue();
			else if(id=="sampleRate") SampleRate=parser.ParseIntValue();
			else if(id=="samples") Samples=parser.ParseIntValue();
			else if(id=="siteID") SiteID=parser.ParseIntValue();
			else if(id=="tdlType") TdlType=parser.ParseIntValue();
			else if(id=="whichGeometry") WhichGeometry=parser.ParseIntValue();
			else if(id=="writeInterval") WriteInterval=parser.ParseDoubleValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
