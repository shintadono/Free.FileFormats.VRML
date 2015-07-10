using System;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The Arc node specifies a linear circular arc whose center is at (0,0)
	/// and whose angles are measured starting at the positive x-axis and
	/// sweeping towards the positive y-axis.
	/// </summary>
	public class x3dArc2D : X3DNode, X3DGeometryNode
	{
		public double EndAngle { get; set; }
		public double Radius { get; set; }
		public double StartAngle { get; set; }

		public x3dArc2D()
		{
			EndAngle=Math.PI/2;
			Radius=1;
			StartAngle=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dArc2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="endAngle") EndAngle=parser.ParseDoubleValue();
			else if(id=="radius") Radius=parser.ParseDoubleValue();
			else if(id=="startAngle") StartAngle=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
