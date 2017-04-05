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
		public void Process_CorrectMatrix_ReturnCorrectResult()
		{
			const byte value = 123;
			var matrix = CreateTestMatrix(value);
			var alg = new SuperAlg() { Value = value };

			var result = alg.Process(matrix);

			Expect(result, Is.EqualTo(matrix.Data.Length / 2));
		}

		[Test]
		public void Process_MatrixIsNull_Exception()
		{
			var alg = new SuperAlg();

			Expect(() => alg.Process(null), Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public void Process_ReturnCorrectResult()
		{
			var matrix = new Matrix(100, 200);
			var alg = new SuperAlg();

			var result = alg.Process(matrix);

			Expect(result, Is.EqualTo(20000));
		}

		private static Matrix CreateTestMatrix(byte value)
		{
			var matrix = new Matrix(100, 200);
			for(var i = 0; i < matrix.Data.Length / 2; i++)
			{
				matrix.Data[i] = value;
			}
			return matrix;
		}
	}
}
// ReSharper restore InconsistentNaming

