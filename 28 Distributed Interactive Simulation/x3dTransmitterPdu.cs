using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The TransmitterPdu provides detailed information about a radio transmitter.
	/// </summary>
	public class x3dTransmitterPdu : X3DNode, X3DSensorNode, X3DBoundedObject
	{
		public string Address { get; set; }
		public SFVec3f AntennaLocation { get; set; }
		public int AntennaPatternLength { get; set; }
		public int AntennaPatternType { get; set; }
		public int ApplicationID { get; set; }
		public int CryptoKeyID { get; set; }
		public int CryptoSystem { get; set; }
		public bool Enabled { get; set; }
		public int EntityID { get; set; }
		public int Frequency { get; set; }
		public int InputSource { get; set; }
		public int LengthOfModulationParameters { get; set; }
		public int ModulationTypeDetail { get; set; }
		public int ModulationTypeMajor { get; set; }
		public int ModulationTypeSpreadSpectrum { get; set; }
		public int ModulationTypeSystem { get; set; }
		public string MulticastRelayHost { get; set; }
		public int MulticastRelayPort { get; set; }
		public string NetworkMode { get; set; }
		public int Port { get; set; }
		public double Power { get; set; }
		public int RadioEntityTypeCategory { get; set; }
		public int RadioEntityTypeCountry { get; set; }
		public int RadioEntityTypeDomain { get; set; }
		public int RadioEntityTypeKind { get; set; }
		public int RadioEntityTypeNomenclature { get; set; }
		public int RadioEntityTypeNomenclatureVersion { get; set; }
		public int RadioID { get; set; }
		public double ReadInterval { get; set; }
		public SFVec3f RelativeAntennaLocation { get; set; }
		public bool RtpHeaderExpected { get; set; }
		public int SiteID { get; set; }
		public double TransmitFrequencyBandwidth { get; set; }
		public int TransmitState { get; set; }
		public int WhichGeometry { get; set; }
		public double WriteInterval { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dTransmitterPdu()
		{
			Address="localhost";
			AntennaLocation=new SFVec3f(0, 0, 0);
			AntennaPatternLength=0;
			AntennaPatternType=0;
			ApplicationID=1;
			CryptoKeyID=0;
			CryptoSystem=0;
			Enabled=true;
			EntityID=0;
			Frequency=0;
			InputSource=0;
			LengthOfModulationParameters=0;
			ModulationTypeDetail=0;
			ModulationTypeMajor=0;
			ModulationTypeSpreadSpectrum=0;
			ModulationTypeSystem=0;
			MulticastRelayHost="";
			MulticastRelayPort=0;
			NetworkMode="standAlone";
			Port=0;
			Power=0.0;
			RadioEntityTypeCategory=0;
			RadioEntityTypeCountry=0;
			RadioEntityTypeDomain=0;
			RadioEntityTypeKind=0;
			RadioEntityTypeNomenclature=0;
			RadioEntityTypeNomenclatureVersion=0;
			RadioID=0;
			ReadInterval=0.1;
			RelativeAntennaLocation=new SFVec3f(0, 0, 0);
			RtpHeaderExpected=false;
			SiteID=0;
			TransmitFrequencyBandwidth=0.0;
			TransmitState=0;
			WhichGeometry=1;
			WriteInterval=1.0;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTransmitterPduPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="address") Address=parser.ParseStringValue();
			else if(id=="antennaLocation") AntennaLocation=parser.ParseSFVec3fValue();
			else if(id=="antennaPatternLength") AntennaPatternLength=parser.ParseIntValue();
			else if(id=="antennaPatternType") AntennaPatternType=parser.ParseIntValue();
			else if(id=="applicationID") ApplicationID=parser.ParseIntValue();
			else if(id=="cryptoKeyID") CryptoKeyID=parser.ParseIntValue();
			else if(id=="cryptoSystem") CryptoSystem=parser.ParseIntValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="entityID") EntityID=parser.ParseIntValue();
			else if(id=="frequency") Frequency=parser.ParseIntValue();
			else if(id=="inputSource") InputSource=parser.ParseIntValue();
			else if(id=="lengthOfModulationParameters") LengthOfModulationParameters=parser.ParseIntValue();
			else if(id=="modulationTypeDetail") ModulationTypeDetail=parser.ParseIntValue();
			else if(id=="modulationTypeMajor") ModulationTypeMajor=parser.ParseIntValue();
			else if(id=="modulationTypeSpreadSpectrum") ModulationTypeSpreadSpectrum=parser.ParseIntValue();
			else if(id=="modulationTypeSystem") ModulationTypeSystem=parser.ParseIntValue();
			else if(id=="multicastRelayHost") MulticastRelayHost=parser.ParseStringValue();
			else if(id=="multicastRelayPort") MulticastRelayPort=parser.ParseIntValue();
			else if(id=="networkMode") NetworkMode=parser.ParseStringValue();
			else if(id=="port") Port=parser.ParseIntValue();
			else if(id=="power") Power=parser.ParseDoubleValue();
			else if(id=="radioEntityTypeCategory") RadioEntityTypeCategory=parser.ParseIntValue();
			else if(id=="radioEntityTypeCountry") RadioEntityTypeCountry=parser.ParseIntValue();
			else if(id=="radioEntityTypeDomain") RadioEntityTypeDomain=parser.ParseIntValue();
			else if(id=="radioEntityTypeKind") RadioEntityTypeKind=parser.ParseIntValue();
			else if(id=="radioEntityTypeNomenclature") RadioEntityTypeNomenclature=parser.ParseIntValue();
			else if(id=="radioEntityTypeNomenclatureVersion") RadioEntityTypeNomenclatureVersion=parser.ParseIntValue();
			else if(id=="radioID") RadioID=parser.ParseIntValue();
			else if(id=="readInterval") ReadInterval=parser.ParseDoubleValue();
			else if(id=="relativeAntennaLocation") RelativeAntennaLocation=parser.ParseSFVec3fValue();
			else if(id=="rtpHeaderExpected") RtpHeaderExpected=parser.ParseBoolValue();
			else if(id=="siteID") SiteID=parser.ParseIntValue();
			else if(id=="transmitFrequencyBandwidth") TransmitFrequencyBandwidth=parser.ParseDoubleValue();
			else if(id=="transmitState") TransmitState=parser.ParseIntValue();
			else if(id=="whichGeometry") WhichGeometry=parser.ParseIntValue();
			else if(id=="writeInterval") WriteInterval=parser.ParseDoubleValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
