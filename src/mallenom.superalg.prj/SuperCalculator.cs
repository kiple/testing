using System;
using System.IO;
using System.Linq;

using Mallenom.Imaging;

namespace Mallenom.Super.Tests
{
	public sealed class SuperCalculator
	{
		private readonly SuperProcessor _processor;

		public SuperCalculator()
		{
			_processor = new SuperProcessor(new SuperAlg());
		}

		public int Calculate(string directory)
		{
			var files = Directory.GetFiles(directory);
			var matrixes = files.Select(filename => LoadImage(filename));
			return _processor.Calculate(matrixes);
		}

		public static Matrix LoadImage(string filename)
		{
			switch(Path.GetExtension(filename))
			{
				case ".bmp":
					return Matrix.LoadFrom(filename);
				case ".png":
					var pngmatrix = new CompressedMatrix(filename, PngImageFormat.PngDataFormat);
					var m1 = new Matrix();
					pngmatrix.CopyTo(m1);
					return m1;
				case ".jpg":
				case ".jpeg":
					var jpgmatrix = new CompressedMatrix(filename, JpegImageFormat.JpegDataFormat);
					var m2 = new Matrix();
					jpgmatrix.CopyTo(m2);
					return m2;
			}
			throw new ArgumentException("Неизвестный тип изображения.");
		}

	}
}
