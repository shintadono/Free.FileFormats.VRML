using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// An AudioClip node specifies audio data that can be referenced by Sound nodes.
	/// </summary>
	public class x3dAudioClip : X3DNode, X3DSoundSourceNode, X3DUrlObject
	{
		public string Description { get; set; }
		public bool Loop { get; set; }
		public double PauseTime { get; set; }
		public double Pitch { get; set; }
		public double ResumeTime { get; set; }
		public double StartTime { get; set; }
		public double StopTime { get; set; }
		public List<string> URL { get; set; }

		public x3dAudioClip()
		{
			Description="";
			Loop=false;
			PauseTime=0;
			Pitch=1.0;
			ResumeTime=0;
			StartTime=0;
			StopTime=0;
			URL=new List<string>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dAudioClipPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="description") Description=parser.ParseStringValue();
			else if(id=="loop") Loop=parser.ParseBoolValue();
			else if(id=="pitch") Pitch=parser.ParseDoubleValue();
			else if(id=="startTime") StartTime=parser.ParseDoubleValue();
			else if(id=="stopTime") StopTime=parser.ParseDoubleValue();
			else if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else return false;
			return true;
		}
	}
}
