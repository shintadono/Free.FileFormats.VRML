using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dParticleSystem : X3DNode, X3DShapeNode
	{
		public X3DAppearanceNode Appearance { get; set; }
		public bool CreateParticles { get; set; }
		public X3DGeometryNode Geometry { get; set; }
		public bool Enabled { get; set; }
		public double LifetimeVariation { get; set; }
		public int MaxParticles { get; set; }
		public double ParticleLifetime { get; set; }
		public SFVec2f ParticleSize { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }
		public X3DColorNode ColorRamp { get; set; }
		public List<double> ColorKey { get; set; }
		public X3DParticleEmitterNode Emitter { get; set; }
		public string GeometryType { get; set; }
		public List<X3DParticlePhysicsModelNode> Physics { get; set; }
		public X3DTextureCoordinateNode TexCoordRamp { get; set; }
		public List<double> TexCoordKey { get; set; }

		public x3dParticleSystem()
		{
			CreateParticles=true;
			Enabled=true;
			LifetimeVariation=0.25;
			MaxParticles=200;
			ParticleLifetime=5;
			ParticleSize=new SFVec2f(0.02, 0.02);
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
			ColorKey=new List<double>();
			GeometryType="QUAD";
			Physics=new List<X3DParticlePhysicsModelNode>();
			TexCoordKey=new List<double>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dParticleSystemPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="appearance")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Appearance=node as X3DAppearanceNode;
					if(Appearance==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="createParticles") CreateParticles=parser.ParseBoolValue();
			else if(id=="geometry")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Geometry=node as X3DGeometryNode;
					if(Geometry==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="lifetimeVariation") LifetimeVariation=parser.ParseDoubleValue();
			else if(id=="maxParticles") MaxParticles=parser.ParseIntValue();
			else if(id=="particleLifetime") ParticleLifetime=parser.ParseDoubleValue();
			else if(id=="particleSize") ParticleSize=parser.ParseSFVec2fValue();
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else if(id=="colorRamp")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					ColorRamp=node as X3DColorNode;
					if(ColorRamp==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="colorKey") ColorKey.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="emitter")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Emitter=node as X3DParticleEmitterNode;
					if(Emitter==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="geometryType") GeometryType=parser.ParseStringValue();
			else if(id=="physics")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DParticlePhysicsModelNode ppmn=node as X3DParticlePhysicsModelNode;
					if(ppmn==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Physics.Add(ppmn);
				}
			}
			else if(id=="texCoordRamp")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TexCoordRamp=node as X3DTextureCoordinateNode;
					if(TexCoordRamp==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="texCoordKey") TexCoordKey.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else return false;
			return true;
		}
	}
}
