using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Sound node specifies the spatial presentation of a sound in a X3D scene.
	/// </summary>
	public class x3dSound : X3DNode, X3DSoundNode
	{
		public SFVec3f Direction { get; set; }
		public double Intensity { get; set; }
		public SFVec3f Location { get; set; }
		public double MaxBack { get; set; }
		public double MaxFront { get; set; }
		public double MinBack { get; set; }
		public double MinFront { get; set; }
		public double Priority { get; set; }
		public X3DSoundSourceNode Source { get; set; }
		public bool Spatialize { get; set; }

		public x3dSound()
		{
			Direction=new SFVec3f(0, 0, 1);
			Intensity=1;
			Location=new SFVec3f(0, 0, 0);
			MaxBack=10;
			MaxFront=10;
			MinBack=1;
			MinFront=1;
			Priority=0;
			Spatialize=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSoundPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="direction") Direction=parser.ParseSFVec3fValue();
			else if(id=="intensity") Intensity=parser.ParseDoubleValue();
			else if(id=="location") Location=parser.ParseSFVec3fValue();
			else if(id=="maxBack") MaxBack=parser.ParseDoubleValue();
			else if(id=="maxFront") MaxFront=parser.ParseDoubleValue();
			else if(id=="minBack") MinBack=parser.ParseDoubleValue();
			else if(id=="minFront") MinFront=parser.ParseDoubleValue();
			else if(id=="priority") Priority=parser.ParseDoubleValue();
			else if(id=="source")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Source=node as X3DSoundSourceNode;
					if(Source==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="spatialize") Spatialize=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
