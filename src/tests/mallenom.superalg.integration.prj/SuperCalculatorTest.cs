using System;

using Mallenom.Super.Tests;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super.IntegrationTests
{
	[TestFixture]
	class SuperCalculatorTest : AssertionHelper
	{
		[Test]
		public void Calculate()
		{
			var calc = new SuperCalculator();

			var count = calc.Calculate(Parameters.ImagesDirectory);

			Expect(count, Is.EqualTo(Parameters.Count));
		}
	}
}
// ReSharper restore InconsistentNaming

