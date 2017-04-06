using System;

using JetBrains.dotMemoryUnit;

using Mallenom.Imaging;
using Mallenom.Super.Tests;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super
{
	[TestFixture]
	class SuperAlgMemoryBenchmark : AssertionHelper
	{
		[Test]
		[DotMemoryUnit(CollectAllocations = true, SavingStrategy = SavingStrategy.OnAnyFail)]
		public void TotalTrafficMemory()
		{
			var calc = new SuperCalculator();

			var memoryCheckPoint1 = dotMemory.Check();

			var count = calc.Calculate(Parameters.ImagesDirectory);

			var memoryCheckPoint2 = dotMemory.Check(memory =>
			{
				var allocated = memory.GetTrafficFrom(memoryCheckPoint1).AllocatedMemory;
				Console.WriteLine($"Allocated total: {allocated.ObjectsCount} objects, size: {allocated.SizeInBytes / 1024 / 1024} MBytes.");
				Expect(allocated.ObjectsCount, Is.LessThan(600));
				Expect(allocated.SizeInBytes, Is.LessThan(7 * 1024 * 1024));

				var allocatedMatrixes = memory.GetTrafficFrom(memoryCheckPoint1).Where(obj => obj.Type.Is<Matrix>()).AllocatedMemory;
				Console.WriteLine($"Allocated {nameof(Matrix)}: {allocatedMatrixes.ObjectsCount} objects, {allocatedMatrixes.SizeInBytes} bytes.");
				Expect(allocatedMatrixes.ObjectsCount, Is.EqualTo(12).Within(2));

				Expect(memory.GetObjects(w => w.Type.Is<Matrix>()).ObjectsCount, Is.EqualTo(0));
			});

			//Assert.Fail();
		}
	}
}
// ReSharper restore InconsistentNaming

