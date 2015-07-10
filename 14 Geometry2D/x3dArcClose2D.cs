using System;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The ArcClose node specifies a portion of a circle whose center is at (0,0)
	/// and whose angles are measured starting at the positive x-axis and sweeping
	/// towards the positive y-axis.
	/// </summary>
	public class x3dArcClose2D : X3DNode, X3DGeometryNode
	{
		public string ClosureType { get; set; }
		public double EndAngle { get; set; }
		public double Radius { get; set; }
		public bool Solid { get; set; }
		public double StartAngle { get; set; }

		public x3dArcClose2D()
		{
			ClosureType="PIE";
			EndAngle=Math.PI/2;
			Radius=1;
			Solid=false;
			StartAngle=0;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dArcClose2DPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="closureType") ClosureType=parser.ParseStringValue();
			else if(id=="endAngle") EndAngle=parser.ParseDoubleValue();
			else if(id=="radius") Radius=parser.ParseDoubleValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else if(id=="startAngle") StartAngle=parser.ParseDoubleValue();
			else return false;
			return true;
		}
	}
}
