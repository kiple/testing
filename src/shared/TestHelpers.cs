using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Mallenom.Imaging;

using NUnit.Framework;

namespace Mallenom.Super
{
	public static class Utility
	{
		public static Matrix LoadImage(string filename)
		{
			if(!Path.IsPathRooted(filename))
			{
				filename = Path.Combine(TestContext.CurrentContext.TestDirectory, filename);
			}
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

		public static Matrix LoadImageFromResource(string resourceName)
		{
			switch(Path.GetExtension(resourceName))
			{
				case ".bmp":
					using(var stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName))
					{
						return Matrix.LoadFrom(stream);
					}
				case ".png":
					using(var stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName))
					{
						var pngmatrix = new CompressedMatrix(stream, PngImageFormat.PngDataFormat);
						var matrix = new Matrix();
						pngmatrix.CopyTo(matrix);
						return matrix;
					}
				case ".jpg":
				case ".jpeg":
					using(var stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName))
					{
						var jpgmatrix = new CompressedMatrix(stream, JpegImageFormat.JpegDataFormat);
						var matrix = new Matrix();
						jpgmatrix.CopyTo(matrix);
						return matrix;
					}
			}
			throw new ArgumentException("Неизвестный тип изображения.");

		}

		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
			Func<TSource, TKey> selector)
		{
			return source.MaxBy(selector, Comparer<TKey>.Default);
		}

		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
			Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			using(var sourceIterator = source.GetEnumerator())
			{
				if(!sourceIterator.MoveNext())
				{
					throw new InvalidOperationException("Sequence was empty.");
				}
				var max = sourceIterator.Current;
				var maxKey = selector(max);
				while(sourceIterator.MoveNext())
				{
					var candidate = sourceIterator.Current;
					var candidateProjected = selector(candidate);
					if(comparer.Compare(candidateProjected, maxKey) > 0)
					{
						max = candidate;
						maxKey = candidateProjected;
					}
				}
				return max;
			}
		}

		public static void ForEach<T>(IEnumerable<T> first, IEnumerable<T> second, Action<T, T> action)
		{
			using(var e1 = first.GetEnumerator())
			{
				using(var e2 = second.GetEnumerator())
				{
					while(e1.MoveNext() && e2.MoveNext())
					{
						action(e1.Current, e2.Current);
					}
				}
			}
		}
	}
}
