using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type is the base node type from which all Sequencers are derived.
	/// </summary>
	/// <typeparam name="T">SF&lt;type&gt;</typeparam>
	public interface X3DSequencerNode<T> : X3DChildNode
		where T : X3DField
	{
		List<double> Key { get; set; }
		List<T> KeyValue { get; set; }
	}
}
