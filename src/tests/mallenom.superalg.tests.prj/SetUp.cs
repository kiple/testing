using System;

using Mallenom.Diagnostics.Logs;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
[TestFixture]
class SetUp : AssertionHelper
{
	private static readonly IAppender _logAppender = new ConsoleAppender();

	[OneTimeSetUp]
	public void OneTimeSetUp()
	{
		LogManager.GetRepository().RootLogger.AddAppender(_logAppender);
	}

	[OneTimeTearDown]
	public void OneTimeTearDown()
	{
		LogManager.GetRepository().RootLogger.RemoveAppender(_logAppender);
	}
}
// ReSharper restore InconsistentNaming

