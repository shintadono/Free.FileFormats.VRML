using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class dummyPolygonBackground : X3DNode, X3DChildNode, IDummyNode
	{
		// TODO
		// http://doc.instantreality.org/documentation/nodetype/PolygonBackground/

		internal override X3DPrototypeInstance GetProto() { return new dummyPolygonBackgroundPROTO(); }
	}
}
