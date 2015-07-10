using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		class NameState
		{
			public Dictionary<string, X3DNode> instances;
			public Dictionary<string, X3DPrototypeInstance> protoDefinitions;
			public List<X3DNode> nodes;
			public bool inPROTO;
		}

		Stack<NameState> attic=new Stack<NameState>();

		void PushNameState()
		{
			NameState ns=new NameState();
			ns.instances=instances;
			ns.protoDefinitions=protoDefinitions;
			ns.nodes=nodes;
			ns.inPROTO=inPROTO;

			attic.Push(ns);

			protoDefinitions=new Dictionary<string, X3DPrototypeInstance>(ns.protoDefinitions);

			instances=new Dictionary<string, X3DNode>();

			nodes=new List<X3DNode>();
		}

		void PopNameState()
		{
			NameState ns=attic.Pop();
			instances=ns.instances;
			protoDefinitions=ns.protoDefinitions;
			nodes=ns.nodes;
			inPROTO=ns.inPROTO;
		}
	}
}
