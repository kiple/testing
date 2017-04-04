using System;
using System.Linq;

using Mallenom.Imaging;

namespace Mallenom.Super
{
	public class SuperAlg
	{
		public byte Value { set; get; } = 0;

		public int Process(Matrix matrix)
		{
			return matrix.Data.Count(v => v == Value);
		}
	}
}
