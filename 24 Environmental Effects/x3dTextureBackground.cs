using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The TextureBackground node uses six individual texture nodes to compose the backdrop.
	/// </summary>
	public class x3dTextureBackground : X3DNode, X3DBackgroundNode
	{
		public List<double> GroundAngle { get; set; }
		public List<SFColor> GroundColor { get; set; }
		public X3DTextureNode BackTexture { get; set; }
		public X3DTextureNode BottomTexture { get; set; }
		public X3DTextureNode FrontTexture { get; set; }
		public X3DTextureNode LeftTexture { get; set; }
		public X3DTextureNode RightTexture { get; set; }
		public X3DTextureNode TopTexture { get; set; }
		public List<double> SkyAngle { get; set; }
		public List<SFColor> SkyColor { get; set; }
		public double Transparency { get; set; }

		bool wasSkyColor=false;

		public x3dTextureBackground()
		{
			GroundAngle=new List<double>();
			GroundColor=new List<SFColor>();
			SkyAngle=new List<double>();
			SkyColor=new List<SFColor>();
			SkyColor.Add(new SFColor(0, 0, 0));
			Transparency=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTextureBackgroundPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="groundAngle") GroundAngle.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="groundColor") GroundColor.AddRange(parser.ParseSFColorOrMFColorValue());
			else if(id=="backTexture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					BackTexture=node as X3DTextureNode;
					if(BackTexture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="bottomTexture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					BottomTexture=node as X3DTextureNode;
					if(BottomTexture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="frontTexture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					FrontTexture=node as X3DTextureNode;
					if(FrontTexture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="leftTexture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					LeftTexture=node as X3DTextureNode;
					if(LeftTexture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="rightTexture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					RightTexture=node as X3DTextureNode;
					if(RightTexture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="topTexture")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TopTexture=node as X3DTextureNode;
					if(TopTexture==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="skyAngle") SkyAngle.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else if(id=="skyColor")
			{
				if(wasSkyColor) SkyColor.AddRange(parser.ParseSFColorOrMFColorValue());
				else SkyColor=parser.ParseSFColorOrMFColorValue();
				wasSkyColor=true;
			}
			else if(id=="transparency")
			{
				// since X3D Node Spec and VRML Classic Coding Spec disagree on the fieldType
				List<double> values=parser.ParseSFFloatOrMFFloatValue();
				if(values.Count!=0) Transparency=values[0];
			}
			else return false;
			return true;
		}
	}
}
