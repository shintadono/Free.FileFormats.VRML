using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dCADFace : X3DNode, X3DProductStructureChildNode, X3DBoundedObject, IX3DCADFaceNode
	{
		public IX3DCADFaceShape Shape { get; set; }
		public string Name { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public x3dCADFace()
		{
			Name="";
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dCADFacePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="name") Name=parser.ParseStringValue();
			else if(id=="shape")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Shape=node as IX3DCADFaceShape;
					if(Shape==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}
	}
}
