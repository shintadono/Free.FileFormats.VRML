using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dTextureProperties : X3DNode, IX3DTexturePropertiesNode
	{
		public double AnisotropicDegree { get; set; }
		public SFColorRGBA BorderColor { get; set; }
		public int BorderWidth { get; set; }
		public string BoundaryModeS { get; set; }
		public string BoundaryModeT { get; set; }
		public string BoundaryModeR { get; set; }
		public string MagnificationFilter { get; set; }
		public string MinificationFilter { get; set; }
		public string TextureCompression { get; set; }
		public double TexturePriority { get; set; }
		public bool GenerateMipMaps { get; set; }

		public x3dTextureProperties()
		{
			AnisotropicDegree=1.0;
			BorderColor=new SFColorRGBA(0, 0, 0, 0);
			BorderWidth=0;
			BoundaryModeS="REPEAT";
			BoundaryModeT="REPEAT";
			BoundaryModeR="REPEAT";
			MagnificationFilter="FASTEST";
			MinificationFilter="FASTEST";
			TextureCompression="FASTEST";
			TexturePriority=0;
			GenerateMipMaps=false;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTexturePropertiesPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="anisotropicDegree") AnisotropicDegree=parser.ParseDoubleValue();
			else if(id=="borderColor") BorderColor=parser.ParseSFColorRGBAValue();
			else if(id=="borderWidth") BorderWidth=parser.ParseIntValue();
			else if(id=="boundaryModeS") BoundaryModeS=parser.ParseStringValue();
			else if(id=="boundaryModeT") BoundaryModeT=parser.ParseStringValue();
			else if(id=="boundaryModeR") BoundaryModeR=parser.ParseStringValue();
			else if(id=="magnificationFilter") MagnificationFilter=parser.ParseStringValue();
			else if(id=="minificationFilter") MinificationFilter=parser.ParseStringValue();
			else if(id=="textureCompression") TextureCompression=parser.ParseStringValue();
			else if(id=="texturePriority") TexturePriority=parser.ParseIntValue();
			else if(id=="generateMipMaps") GenerateMipMaps=parser.ParseBoolValue();
			else return false;
			return true;
		}
	}
}
