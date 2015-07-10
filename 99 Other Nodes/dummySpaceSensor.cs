using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	public class dummySpaceSensor : X3DNode, X3DSensorNode, IDummyNode
	{
		// TODO
		// http://doc.instantreality.org/documentation/nodetype/SpaceSensor/

		public bool Enabled { get; set; }

		public dummySpaceSensor()
		{
			Enabled=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new dummySpaceSensorPROTO(); }
	}
}
