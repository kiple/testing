using System;
using System.Linq;

using Mallenom.Imaging;

namespace Mallenom.Super
{
	/// <summary>Алгоритм анализа изображения.</summary>
	public class SuperAlg
	{
		public byte Value { set; get; } = 0;

		public virtual int GetValueCount(Matrix matrix)
		{
			Verify.Argument.IsNotNull(matrix, nameof(matrix));

			return matrix.Data.Count(v => v == Value);
		}
	}
}
