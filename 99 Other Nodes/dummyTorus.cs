using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class dummyTorus : X3DNode, X3DGeometryNode, IDummyNode
	{
		// TODO
		// http://doc.instantreality.org/documentation/nodetype/Torus/

		internal override X3DPrototypeInstance GetProto() { return new dummyTorusPROTO(); }
	}
}
