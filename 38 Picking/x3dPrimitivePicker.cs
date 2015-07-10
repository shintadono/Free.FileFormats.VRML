using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dPrimitivePicker : X3DNode, X3DPickSensorNode
	{
		public bool Enabled { get; set; }
		public List<string> ObjectType { get; set; }
		public X3DGeometryNode PickingGeometry { get; set; }
		public List<IX3DPickSensorNodePickTarget> PickTarget { get; set; }
		public string IntersectionType { get; set; }
		public string SortOrder { get; set; }

		bool wasObjectType=false;

		public x3dPrimitivePicker()
		{
			Enabled=true;
			ObjectType=new List<string>();
			ObjectType.Add("ALL");
			PickTarget=new List<IX3DPickSensorNodePickTarget>();
			IntersectionType="BOUNDS";
			SortOrder="CLOSEST";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dPrimitivePickerPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="objectType")
			{
				if(wasObjectType) ObjectType.AddRange(parser.ParseSFStringOrMFStringValue());
				else ObjectType=parser.ParseSFStringOrMFStringValue();
				wasObjectType=true;
			}
			else if(id=="pickingGeometry")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					PickingGeometry=node as IX3DPrimitivePickerPickingGeometry;
					if(PickingGeometry==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="pickTarget")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					IX3DPickSensorNodePickTarget pt=node as IX3DPickSensorNodePickTarget;
					if(pt==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else PickTarget.Add(pt);
				}
			}
			else if(id=="intersectionType") IntersectionType=parser.ParseStringValue();
			else if(id=="sortOrder") SortOrder=parser.ParseStringValue();
			else return false;
			return true;
		}
	}
}
