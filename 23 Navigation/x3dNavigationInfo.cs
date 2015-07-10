using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The NavigationInfo node contains information describing the
	/// physical characteristics of the viewer's avatar and viewing model.
	/// </summary>
	public class x3dNavigationInfo : X3DNode, X3DBindableNode
	{
		public List<double> AvatarSize { get; set; }
		public bool Headlight { get; set; }
		public double Speed { get; set; }
		public double TransitionTime { get; set; }
		public List<string> TransitionType { get; set; }
		public List<string> Type { get; set; }
		public double VisibilityLimit { get; set; }

		bool wasAvatarSize=false, wasTransitionType=false, wasType=false;

		public x3dNavigationInfo()
		{
			AvatarSize=new List<double>();
			AvatarSize.Add(0.25);
			AvatarSize.Add(1.6);
			AvatarSize.Add(0.75);
			Headlight=true;
			Speed=1.0;
			TransitionTime=1.0;
			TransitionType=new List<string>();
			TransitionType.Add("LINEAR");
			Type=new List<string>();
			Type.Add("EXAMINE");
			Type.Add("ANY");
			VisibilityLimit=0.0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dNavigationInfoPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="avatarSize")
			{
				if(wasAvatarSize) AvatarSize.AddRange(parser.ParseSFFloatOrMFFloatValue());
				else AvatarSize=parser.ParseSFFloatOrMFFloatValue();
				wasAvatarSize=true;
			}
			else if(id=="headlight") Headlight=parser.ParseBoolValue();
			else if(id=="speed") Speed=parser.ParseDoubleValue();
			else if(id=="transitionTime") TransitionTime=parser.ParseDoubleValue();
			else if(id=="transitionType")
			{
				if(wasTransitionType) TransitionType.AddRange(parser.ParseSFStringOrMFStringValue());
				else TransitionType=parser.ParseSFStringOrMFStringValue();
				wasTransitionType=true;
			}
			else if(id=="type")
			{
				if(wasType) Type.AddRange(parser.ParseSFStringOrMFStringValue());
				else Type=parser.ParseSFStringOrMFStringValue();
				wasType=true;
			}
			else if(id=="visibilityLimit") VisibilityLimit=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
