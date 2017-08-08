using System;

using Mallenom.Diagnostics.Logs;
using Mallenom.Imaging;

using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Mallenom.Super.Tests
{
	[TestFixture]
	class SuperAlgTests
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			LogManager.GetRepository().RootLogger.AddAppender(new ConsoleAppender());
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
		}

		[SetUp]
		public void SetUp()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}

		[Test]
		public void GetValueCount_CorrectMatrix_ReturnCorrectResult()
		{
			// Arrange
			const byte value = 123;
			var matrix = CreateTestMatrix(value);
			var alg = new SuperAlg() { Value = value };

			// Act
			var result = alg.GetValueCount(matrix);

			// Assert
			Assert.That(result, Is.EqualTo(matrix.Data.Length / 2));
		}

		[Test]
		public void GetValueCount_MatrixIsNull_Exception()
		{
			var alg = new SuperAlg();

			Assert.That(() => alg.GetValueCount(null), Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public void GetValueCount_RealImage_ReturnCorrectResult()
		{
			var matrix = Utility.LoadImage(@"data\M101CM178.jpg");
			var alg = new SuperAlg() { Value = 128};

			var result = alg.GetValueCount(matrix);

			Assert.That(result, Is.EqualTo(333));
		}

		[Test]
		[TestCase(@"data\M101CM178.jpg", 128, ExpectedResult = 333)]
		[TestCase(@"data\T173XT35.jpg", 230, ExpectedResult = 217)]
		public int Process_RealImages_ReturnCorrectResult(string filename, byte value)
		{
			var matrix = Utility.LoadImage(filename);
			var alg = new SuperAlg() { Value = value };

			return alg.GetValueCount(matrix);
		}

		private static object[] RealMatrixes => new object[]
		{
			new object[] { Utility.LoadImage(@"data\M101CM178.jpg"), 128, 333 },
			new object[] { Utility.LoadImage(@"data\T173XT35.jpg"), 230, 217 },
		};

		[Test, TestCaseSource(nameof(RealMatrixes))]
		public void Process_RealImages_ReturnCorrectResult1(Matrix matrix, int value, int ExpectedResult)
		{
			var alg = new SuperAlg() { Value = (byte)value };

			var result = alg.GetValueCount(matrix);

			Assert.That(result, Is.EqualTo(ExpectedResult));
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

