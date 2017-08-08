using System;

using JetBrains.dotMemoryUnit;

using Mallenom.Imaging;
using Mallenom.Super.Tests;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super
{
	[TestFixture]
	class SuperAlgMemoryBenchmark
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
				Assert.That(allocated.ObjectsCount, Is.LessThan(600));
				Assert.That(allocated.SizeInBytes, Is.LessThan(7 * 1024 * 1024));

				var allocatedMatrixes = memory.GetTrafficFrom(memoryCheckPoint1).Where(obj => obj.Type.Is<Matrix>()).AllocatedMemory;
				Console.WriteLine($"Allocated {nameof(Matrix)}: {allocatedMatrixes.ObjectsCount} objects, {allocatedMatrixes.SizeInBytes} bytes.");
				Assert.That(allocatedMatrixes.ObjectsCount, Is.EqualTo(12).Within(2));

				Assert.That(memory.GetObjects(w => w.Type.Is<Matrix>()).ObjectsCount, Is.EqualTo(0));
			});

			//Assert.Fail();
		}
	}
}
// ReSharper restore InconsistentNaming

