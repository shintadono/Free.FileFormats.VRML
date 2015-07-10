using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML
{
	public partial class VRMLParser
	{
		static CultureInfo nc=new CultureInfo("");

		StreamReader stream;

		#region Line
		int line;
		public int Line { get { return line; } }
		#endregion

		#region ProgressInfo
		Func<double, bool> progressInfo;
		int lastProgressInfoLine;
		int progressInfoLineDelta=100;
		#endregion

		#region NameState
		Dictionary<string, X3DPrototypeInstance> protoDefinitions=new Dictionary<string, X3DPrototypeInstance>();
		Dictionary<string, X3DNode> instances=new Dictionary<string, X3DNode>();
		List<X3DNode> nodes=new List<X3DNode>();
		bool inPROTO=false;
		#endregion

		VRMLParserErrorHandling errorHandling=new VRMLParserErrorHandling();

		VRMLParser(StreamReader stream, Func<double, bool> progressInfo, VRMLParserErrorHandling errorHandling)
		{
			try
			{
				if(errorHandling==null) errorHandling=new VRMLParserErrorHandling();

				this.stream=stream;
				this.progressInfo=progressInfo;
				this.errorHandling=errorHandling;

				lastProgressInfoLine=line=1;
				ParseX3DScene();

				if(attic.Count!=0) ErrorUnexpectedEndOfStream();
			}
			catch
			{
				if(!errorHandling.AlwaysReturnSuccessful) throw;
				while(attic.Count>0) PopNameState();
			}
			finally
			{
				stream.Close();
			}
		}

		public static Scene Parse(StreamReader stream)
		{
			return Parse(stream, null);
		}

		public static Scene Parse(StreamReader stream, Func<double, bool> progressInfo)
		{
			return Parse(stream, progressInfo, null);
		}

		public static Scene Parse(StreamReader stream, Func<double, bool> progressInfo, VRMLParserErrorHandling errorHandling)
		{
			Scene ret=new Scene();
			VRMLParser parser=new VRMLParser(stream, progressInfo, errorHandling);
			foreach(X3DNode node in parser.nodes)
			{
				X3DChildNode child=node as X3DChildNode;
				if(child==null) continue; // TODO
				ret.Nodes.Add(child);
			}
			return ret;
		}
	}
}
