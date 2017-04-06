using System;
using System.Linq;

using Mallenom.Imaging;

namespace Mallenom.Super
{
	public class SuperAlg
	{
		public byte Value { set; get; } = 0;

		public virtual int Process(Matrix matrix)
		{
			Verify.Argument.IsNotNull(matrix, nameof(matrix));

			return matrix.Data.Count(v => v == Value);
		}
	}
}
