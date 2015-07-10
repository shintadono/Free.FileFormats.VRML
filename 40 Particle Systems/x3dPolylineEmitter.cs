using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPolylineEmitter : X3DNode, X3DParticleEmitterNode
	{
		public X3DCoordinateNode Coord { get; set; }
		public SFVec3f Direction { get; set; }
		public double Speed { get; set; }
		public double Variation { get; set; }
		public List<int> CoordIndex { get; set; }
		public double Mass { get; set; }
		public double SurfaceArea { get; set; }

		bool wasCoordIndex=false;

		public x3dPolylineEmitter()
		{
			Direction=new SFVec3f(0, 1, 0);
			Speed=0;
			Variation=0.25;
			CoordIndex=new List<int>();
			CoordIndex.Add(-1);
			Mass=0;
			SurfaceArea=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPolylineEmitterPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="coord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Coord=node as X3DCoordinateNode;
					if(Coord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="direction") Direction=parser.ParseSFVec3fValue();
			else if(id=="speed") Speed=parser.ParseDoubleValue();
			else if(id=="variation") Variation=parser.ParseDoubleValue();
			else if(id=="coordIndex")
			{
				if(wasCoordIndex) CoordIndex.AddRange(parser.ParseSFInt32OrMFInt32Value());
				else CoordIndex=parser.ParseSFInt32OrMFInt32Value();
				wasCoordIndex=true;
			}
			else if(id=="mass") Mass=parser.ParseDoubleValue();
			else if(id=="surfaceArea") SurfaceArea=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
