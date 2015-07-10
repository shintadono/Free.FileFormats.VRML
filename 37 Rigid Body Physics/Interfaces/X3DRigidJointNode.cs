using System.Collections.Generic;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.Interfaces
{
	public interface X3DRigidJointNode
	{
		IX3DRigidBodyNode Body1 { get; set; }
		IX3DRigidBodyNode Body2 { get; set; }
		List<string> ForceOutput { get; set; }
	}
}
