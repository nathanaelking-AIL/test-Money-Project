using System;
using System.Collections.Generic;
using System.Linq;

namespace Money.Core.Calculators
{
    internal class MoneyCalculator
    {
        public MoneyCalculator()
        {
        }

        internal Money Max(IEnumerable<Money> monies)
        {
            return new Money
            {
                Amount = monies.Max(x => x.Amount),
                Currency = monies.FirstOrDefault().Currency
            };
        }
    }
}