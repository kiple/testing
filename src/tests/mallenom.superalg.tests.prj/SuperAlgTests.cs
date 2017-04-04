using System;

using Mallenom.Imaging;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super.Tests
{
	[TestFixture]
	class SuperAlgTests : AssertionHelper
	{
		[Test]
		public void Test()
		{
			var alg = new SuperAlg();
			var matrix = new Matrix(100, 200);

			var result = alg.Process(matrix);

			Expect(() => result, Is.EqualTo(20000));
		}
	}
}
// ReSharper restore InconsistentNaming

