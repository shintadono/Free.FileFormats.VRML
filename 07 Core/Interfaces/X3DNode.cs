using System;
using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.RouteDeclarations;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// This abstract node type is the base type for all nodes in the X3D system.
	/// </summary>
	public abstract class X3DNode : SFNode
	{
		public X3DMetadataObject Metadata { get; set; }

		// all fields not known by X3DNode-based types
		public Dictionary<string, X3DFieldBase> Fields=new Dictionary<string, X3DFieldBase>();

		// DEF Name
		public string NameDEF;

		// IS Statements
		public Dictionary<string, string> Substitutions=new Dictionary<string, string>();

		// ROUTE Statements
		public List<RouteDeclaration> Routes=new List<RouteDeclaration>();

		internal virtual X3DPrototypeInstance GetProto() { throw new NotImplementedException(); }

		internal virtual bool ParseNodeBodyElement(string id, VRMLParser parser) { return false; }

		internal string GetNodeName()
		{
			string name=this.GetType().Name;
			if(name.StartsWith("x3d")) name=name.Substring(3);

			if(this is X3DPrototypeInstance)
				return ((X3DPrototypeInstance)this).ProtoNodeName+" (based on: "+name+")";

			return name;
		}
	}
}
