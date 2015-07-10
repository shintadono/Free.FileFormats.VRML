using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dSurfaceEmitter : X3DNode, X3DParticleEmitterNode
	{
		public double Speed { get; set; }
		public double Variation { get; set; }
		public List<int> CoordIndex { get; set; }
		public double Mass { get; set; }
		public X3DGeometryNode Surface { get; set; }
		public double SurfaceArea { get; set; }

		bool wasCoordIndex=false;

		public x3dSurfaceEmitter()
		{
			Speed=0;
			Variation=0.25;
			CoordIndex=new List<int>();
			Mass=0;
			SurfaceArea=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dSurfaceEmitterPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="speed") Speed=parser.ParseDoubleValue();
			else if(id=="variation") Variation=parser.ParseDoubleValue();
			else if(id=="coordIndex")
			{
				if(wasCoordIndex) CoordIndex.AddRange(parser.ParseSFInt32OrMFInt32Value());
				else CoordIndex=parser.ParseSFInt32OrMFInt32Value();
				wasCoordIndex=true;
			}
			else if(id=="mass") Mass=parser.ParseDoubleValue();
			else if(id=="surface")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Surface=node as X3DGeometryNode;
					if(Surface==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="surfaceArea") SurfaceArea=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
