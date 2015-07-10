using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The LoadSensor monitors the progress and success of downloading URL
	/// elements over a network.
	/// </summary>
	public class x3dLoadSensor : X3DNode, X3DNetworkSensorNode
	{
		public bool Enabled { get; set; }
		public double TimeOut { get; set; }
		public List<X3DUrlObject> WatchList { get; set; }

		public x3dLoadSensor()
		{
			Enabled=true;
			TimeOut=0;
			WatchList=new List<X3DUrlObject>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dLoadSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="timeOut") TimeOut=parser.ParseDoubleValue();
			else if(id=="watchList")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DUrlObject url=node as X3DUrlObject;
					if(url==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else WatchList.Add(url);
				}
			}
			else return false;
			return true;
		}
	}
}
