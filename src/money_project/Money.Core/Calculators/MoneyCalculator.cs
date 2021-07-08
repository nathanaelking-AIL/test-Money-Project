using System;
using System.Collections.Generic;
using System.Linq;
using MoneyModule.Core.Domain;

namespace MoneyModule.Core.Calculators
{
    public class MoneyCalculator
    {
        public MoneyCalculator()
        {
        }

        public Money Max(IEnumerable<IMoney> monies)
        {
            return new Money
            {
                Amount = monies.Max(x => x.Amount),
                Currency = monies.FirstOrDefault().Currency
            };
        }
    }
}