using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// The abstract node X3DInterpolatorNode forms the basis for all types of interpolators specified in this clause.
	/// </summary>
	/// <typeparam name="T">SF&lt;type&gt;</typeparam>
	public interface X3DInterpolatorNode<T> : X3DChildNode
		where T : X3DField
	{
		List<double> Key { get; set; }
		List<T> KeyValue { get; set; }
	}
}
