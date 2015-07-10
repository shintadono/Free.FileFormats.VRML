using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Shape node has two fields, appearance and geometry, that are used to
	/// create rendered objects in the world.
	/// </summary>
	public class x3dShape : X3DNode, X3DShapeNode
	{
		public X3DAppearanceNode Appearance { get; set; }
		public X3DGeometryNode Geometry { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dShape()
		{
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dShapePROTO(); }

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
			else if(id=="geometry")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Geometry=node as X3DGeometryNode;
					if(Geometry==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
