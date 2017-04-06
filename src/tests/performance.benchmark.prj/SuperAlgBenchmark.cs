using System;
using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

using Mallenom.Imaging;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super
{
	[TestFixture]
	public class SuperAlgBenchmark : AssertionHelper
	{
		public class Config : ManualConfig
		{
			public Config()
			{
//				Add(Job.Clr.With(Jit.LegacyJit));
//				Add(Job.Default
//					.WithWarmupCount(1)
//					.WithTargetCount(3)
//					.WithLaunchCount(2));
//				KeepBenchmarkFiles = true;
				Add(ConsoleLogger.Default);
				Add(TargetMethodColumn.Method);
				Add(StatisticColumn.AllStatistics);
				Add(MarkdownExporter.Console);
			}
		}

		private SuperAlg _alg;

		private Matrix _matrix;

		[Setup]
		public void Setup()
		{
			_matrix = Utility.LoadImageFromResource("Mallenom.Super.data.M101CM178.jpg");
			_alg = new SuperAlg();
		}

		[Test]
		public void Run()
		{
			var currentDirectory = Environment.CurrentDirectory;
			Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
			var summary = BenchmarkRunner.Run<SuperAlgBenchmark>(new Config());
			Environment.CurrentDirectory = currentDirectory;
		}

		[Benchmark]
		public int Process()
		{
			return _alg.Process(_matrix);
		}
	}
}
// ReSharper restore InconsistentNaming

