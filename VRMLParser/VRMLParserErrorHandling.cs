using System;

namespace Free.FileFormats.VRML
{
	public delegate void ReportErrorAndWarning(string message);

	public sealed class VRMLParserErrorHandling
	{
		public bool AlwaysReturnSuccessful=true;
		public ProtoNodePriorization ProtoNodePriorization=ProtoNodePriorization.ProtoNodeSecondWarn;
		public UnknownNodeHandling UnknownNode=UnknownNodeHandling.ParseAsExternProtoWarn;
		public DummyNodeHandling DummyNode=DummyNodeHandling.Warn;
		public ErrorWarnIgnore PROTOAlreadyDefined=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore MultipleISStatementForField=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore UnexpectedNodeType=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore UnknownFieldInNode=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore USENameNotDefined=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore RouteSourceNameNotDefined=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore RouteTargetNameNotDefined=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore RedundantISStatement=ErrorWarnIgnore.Warn;
		public ErrorWarnIgnore ImproperInitializationOfMFNode=ErrorWarnIgnore.Warn;
		public ReportErrorAndWarning ReportErrorAndWarning=WriteWarning;

		static void WriteWarning(string message)
		{
			Console.WriteLine(message);
		}
	}
}
