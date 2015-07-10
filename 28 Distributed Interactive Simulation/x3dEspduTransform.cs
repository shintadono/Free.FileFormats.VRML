using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// EspduTransform integrates functionality of the following DIS PDUs:
	/// EntityStatePDU, CollisionPDU, DetonationPDU, FirePDU, CreateEntity, and RemoveEntity.
	/// </summary>
	public class x3dEspduTransform : X3DNode, X3DGroupingNode, X3DSensorNode
	{
		public string Address { get; set; }
		public int ApplicationID { get; set; }
		public int ArticulationParameterCount { get; set; }
		public List<int> ArticulationParameterDesignatorArray { get; set; }
		public List<int> ArticulationParameterChangeIndicatorArray { get; set; }
		public List<int> ArticulationParameterIdPartAttachedToArray { get; set; }
		public List<int> ArticulationParameterTypeArray { get; set; }
		public List<double> ArticulationParameterArray { get; set; }
		public SFVec3f Center { get; set; }
		public List<X3DChildNode> Children { get; set; }
		public int CollisionType { get; set; }
		public int DeadReckoning { get; set; }
		public SFVec3f DetonationLocation { get; set; }
		public SFVec3f DetonationRelativeLocation { get; set; }
		public int DetonationResult { get; set; }
		public bool Enabled { get; set; }
		public int EntityCategory { get; set; }
		public int EntityCountry { get; set; }
		public int EntityDomain { get; set; }
		public int EntityExtra { get; set; }
		public int EntityID { get; set; }
		public int EntityKind { get; set; }
		public int EntitySpecific { get; set; }
		public int EntitySubCategory { get; set; }
		public int EventApplicationID { get; set; }
		public int EventEntityID { get; set; }
		public int EventNumber { get; set; }
		public int EventSiteID { get; set; }
		public bool Fired1 { get; set; }
		public bool Fired2 { get; set; }
		public int FireMissionIndex { get; set; }
		public double FiringRange { get; set; }
		public int FiringRate { get; set; }
		public int ForceID { get; set; }
		public int Fuse { get; set; }
		public SFVec3f LinearVelocity { get; set; }
		public SFVec3f LinearAcceleration { get; set; }
		public string Marking { get; set; }
		public string MulticastRelayHost { get; set; }
		public int MulticastRelayPort { get; set; }
		public int MunitionApplicationID { get; set; }
		public SFVec3f MunitionEndPoint { get; set; }
		public int MunitionEntityID { get; set; }
		public int MunitionQuantity { get; set; }
		public int MunitionSiteID { get; set; }
		public SFVec3f MunitionStartPoint { get; set; }
		public string NetworkMode { get; set; }
		public int Port { get; set; }
		public double ReadInterval { get; set; }
		public SFRotation Rotation { get; set; }
		public SFVec3f Scale { get; set; }
		public SFRotation ScaleOrientation { get; set; }
		public int SiteID { get; set; }
		public SFVec3f Translation { get; set; }
		public int Warhead { get; set; }
		public double WriteInterval { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public bool RtpHeaderExpected { get; set; }

		public x3dEspduTransform()
		{
			Address="localhost";
			ApplicationID=1;
			ArticulationParameterCount=0;
			ArticulationParameterDesignatorArray=new List<int>();
			ArticulationParameterChangeIndicatorArray=new List<int>();
			ArticulationParameterIdPartAttachedToArray=new List<int>();
			ArticulationParameterTypeArray=new List<int>();
			ArticulationParameterArray=new List<double>();
			Center=new SFVec3f(0, 0, 0);
			Children=new List<X3DChildNode>();
			CollisionType=0;
			DeadReckoning=0;
			DetonationLocation=new SFVec3f(0, 0, 0);
			DetonationRelativeLocation=new SFVec3f(0, 0, 0);
			DetonationResult=0;
			Enabled=true;
			EntityCategory=0;
			EntityCountry=0;
			EntityDomain=0;
			EntityExtra=0;
			EntityID=0;
			EntityKind=0;
			EntitySpecific=0;
			EntitySubCategory=0;
			EventApplicationID=1;
			EventEntityID=0;
			EventNumber=0;
			EventSiteID=0;
			Fired1=false;
			Fired2=false;
			FireMissionIndex=0;
			FiringRange=0.0;
			FiringRate=0;
			ForceID=0;
			Fuse=0;
			LinearVelocity=new SFVec3f(0, 0, 0);
			LinearAcceleration=new SFVec3f(0, 0, 0);
			Marking="";
			MulticastRelayHost="";
			MulticastRelayPort=0;
			MunitionApplicationID=1;
			MunitionEndPoint=new SFVec3f(0, 0, 0);
			MunitionEntityID=0;
			MunitionQuantity=0;
			MunitionSiteID=0;
			MunitionStartPoint=new SFVec3f(0, 0, 0);
			NetworkMode="standAlone";
			Port=0;
			ReadInterval=0.1;
			Rotation=new SFRotation(0, 0, 1, 0);
			Scale=new SFVec3f(1, 1, 1);
			ScaleOrientation=new SFRotation(0, 0, 1, 0);
			SiteID=0;
			Translation=new SFVec3f(0, 0, 0);
			Warhead=0;
			WriteInterval=1.0;
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
			RtpHeaderExpected=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dEspduTransformPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="address") Address=parser.ParseStringValue();
			else if(id=="applicationID") ApplicationID=parser.ParseIntValue();
			else if(id=="articulationParameterCount") ArticulationParameterCount=parser.ParseIntValue();
			else if(id=="articulationParameterDesignatorArray") ArticulationParameterDesignatorArray.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="articulationParameterChangeIndicatorArray") ArticulationParameterChangeIndicatorArray.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="articulationParameterIdPartAttachedToArray") ArticulationParameterIdPartAttachedToArray.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="articulationParameterTypeArray") ArticulationParameterTypeArray.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="articulationParameterArray") ArticulationParameterArray.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="center") Center=parser.ParseSFVec3fValue();
			else if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="collisionType") CollisionType=parser.ParseIntValue();
			else if(id=="deadReckoning") DeadReckoning=parser.ParseIntValue();
			else if(id=="detonationLocation") DetonationLocation=parser.ParseSFVec3fValue();
			else if(id=="detonationRelativeLocation") DetonationRelativeLocation=parser.ParseSFVec3fValue();
			else if(id=="detonationResult") DetonationResult=parser.ParseIntValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="entityCategory") EntityCategory=parser.ParseIntValue();
			else if(id=="entityCountry") EntityCountry=parser.ParseIntValue();
			else if(id=="entityDomain") EntityDomain=parser.ParseIntValue();
			else if(id=="entityExtra") EntityExtra=parser.ParseIntValue();
			else if(id=="entityID") EntityID=parser.ParseIntValue();
			else if(id=="entityKind") EntityKind=parser.ParseIntValue();
			else if(id=="entitySpecific") EntitySpecific=parser.ParseIntValue();
			else if(id=="entitySubCategory") EntitySubCategory=parser.ParseIntValue();
			else if(id=="eventApplicationID") EventApplicationID=parser.ParseIntValue();
			else if(id=="eventEntityID") EventEntityID=parser.ParseIntValue();
			else if(id=="eventNumber") EventNumber=parser.ParseIntValue();
			else if(id=="eventSiteID") EventSiteID=parser.ParseIntValue();
			else if(id=="fired1") Fired1=parser.ParseBoolValue();
			else if(id=="fired2") Fired2=parser.ParseBoolValue();
			else if(id=="fireMissionIndex") FireMissionIndex=parser.ParseIntValue();
			else if(id=="firingRange") FiringRange=parser.ParseDoubleValue();
			else if(id=="firingRate") FiringRate=parser.ParseIntValue();
			else if(id=="forceID") ForceID=parser.ParseIntValue();
			else if(id=="fuse") Fuse=parser.ParseIntValue();
			else if(id=="linearVelocity") LinearVelocity=parser.ParseSFVec3fValue();
			else if(id=="linearAcceleration") LinearAcceleration=parser.ParseSFVec3fValue();
			else if(id=="marking") Marking=parser.ParseStringValue();
			else if(id=="multicastRelayHost") MulticastRelayHost=parser.ParseStringValue();
			else if(id=="multicastRelayPort") MulticastRelayPort=parser.ParseIntValue();
			else if(id=="munitionApplicationID") MunitionApplicationID=parser.ParseIntValue();
			else if(id=="munitionEndPoint") MunitionEndPoint=parser.ParseSFVec3fValue();
			else if(id=="munitionEntityID") MunitionEntityID=parser.ParseIntValue();
			else if(id=="munitionQuantity") MunitionQuantity=parser.ParseIntValue();
			else if(id=="munitionSiteID") MunitionSiteID=parser.ParseIntValue();
			else if(id=="munitionStartPoint") MunitionStartPoint=parser.ParseSFVec3fValue();
			else if(id=="networkMode") NetworkMode=parser.ParseStringValue();
			else if(id=="port") Port=parser.ParseIntValue();
			else if(id=="readInterval") ReadInterval=parser.ParseDoubleValue();
			else if(id=="rotation") Rotation=parser.ParseSFRotationValue();
			else if(id=="scale") Scale=parser.ParseSFVec3fValue();
			else if(id=="scaleOrientation") ScaleOrientation=parser.ParseSFRotationValue();
			else if(id=="siteID") SiteID=parser.ParseIntValue();
			else if(id=="translation") Translation=parser.ParseSFVec3fValue();
			else if(id=="warhead") Warhead=parser.ParseIntValue();
			else if(id=="writeInterval") WriteInterval=parser.ParseDoubleValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else if(id=="rtpHeaderExpected") RtpHeaderExpected=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
