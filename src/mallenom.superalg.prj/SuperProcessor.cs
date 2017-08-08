using System;
using System.Collections.Generic;
using System.Linq;

using Mallenom.Imaging;

namespace Mallenom.Super
{
	public sealed class SuperProcessor
	{
		private readonly SuperAlg _alg;

		public SuperProcessor(SuperAlg alg)
		{
			Verify.Argument.IsNotNull(alg, nameof(alg));

			_alg = alg;
		}

		public int Calculate(IEnumerable<Matrix> matrixes)
		{
			return matrixes.Sum(m => _alg.GetValueCount(m));
		}
	}
}
