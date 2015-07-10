using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// BooleanFilter filters Boolean events, allowing for selective routing of TRUE or FALSE values and negation.
	/// </summary>
	public class x3dBooleanFilter : X3DNode, X3DChildNode
	{
		public x3dBooleanFilter()
		{
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBooleanFilterPROTO(); }
	}
}
