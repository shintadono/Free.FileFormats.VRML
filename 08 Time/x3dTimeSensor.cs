using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTimeSensor : X3DNode, X3DTimeDependentNode, X3DSensorNode
	{
		/// <summary>
		/// TimeSensor nodes generate events as time passes.
		/// </summary>
		public double CycleInterval { get; set; }
		public bool Enabled { get; set; }
		public bool Loop { get; set; }
		public double PauseTime { get; set; }
		public double ResumeTime { get; set; }
		public double StartTime { get; set; }
		public double StopTime { get; set; }

		public x3dTimeSensor()
		{
			CycleInterval=1;
			Enabled=true;
			Loop=false;
			PauseTime=0;
			ResumeTime=0;
			StartTime=0;
			StopTime=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTimeSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="cycleInterval") CycleInterval=parser.ParseDoubleValue();
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="loop") Loop=parser.ParseBoolValue();
			else if(id=="pauseTime") PauseTime=parser.ParseDoubleValue();
			else if(id=="resumeTime") ResumeTime=parser.ParseDoubleValue();
			else if(id=="startTime") StartTime=parser.ParseDoubleValue();
			else if(id=="stopTime") StopTime=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
