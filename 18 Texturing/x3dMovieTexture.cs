using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMovieTexture : X3DNode, X3DTexture2DNode, X3DSoundSourceNode, X3DUrlObject
	{
		public string Description { get; set; }
		public bool Loop { get; set; }
		public double PauseTime { get; set; }
		public double ResumeTime { get; set; }
		public double Speed { get; set; }
		public double StartTime { get; set; }
		public double StopTime { get; set; }
		public List<string> URL { get; set; }
		public bool RepeatS { get; set; }
		public bool RepeatT { get; set; }
		public IX3DTexturePropertiesNode TextureProperties { get; set; }

		// Overrides Speed
		public double Pitch { get { return Speed; } set { Speed=value; } }

		public x3dMovieTexture()
		{
			Description="";
			Loop=false;
			PauseTime=0;
			ResumeTime=0;
			Speed=1.0;
			StartTime=0;
			StopTime=0;
			URL=new List<string>();
			RepeatS=true;
			RepeatT=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMovieTexturePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="description") Description=parser.ParseStringValue();
			else if(id=="loop") Loop=parser.ParseBoolValue();
			else if(id=="pauseTime") PauseTime=parser.ParseDoubleValue();
			else if(id=="resumeTime") ResumeTime=parser.ParseDoubleValue();
			else if(id=="speed"||id=="pitch") Pitch=parser.ParseDoubleValue();
			else if(id=="startTime") StartTime=parser.ParseDoubleValue();
			else if(id=="stopTime") StopTime=parser.ParseDoubleValue();
			else if(id=="url") URL.AddRange(parser.ParseSFStringOrMFStringValue());
			else if(id=="repeatS") RepeatS=parser.ParseBoolValue();
			else if(id=="repeatT") RepeatT=parser.ParseBoolValue();
			else if(id=="textureProperties")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TextureProperties=node as IX3DTexturePropertiesNode;
					if(TextureProperties==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else return false;
			return true;
		}
	}
}
