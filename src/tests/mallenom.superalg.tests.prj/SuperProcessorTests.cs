using System;

using Mallenom.Imaging;

using Moq;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super.Tests
{
	[TestFixture]
	class SuperProcessorTests
	{
		[Test]
		public void Calculate()
		{
			var alg = new Mock<SuperAlg>();
			alg.Setup(a => a.GetValueCount(It.IsAny<Matrix>())).Returns(() => 100);
			var processor = new SuperProcessor(alg.Object);

			var count = processor.Calculate(new[] { new Matrix(), new Matrix() });

			Assert.That(count, Is.EqualTo(200));
		}
	}
}
// ReSharper restore InconsistentNaming
