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
            if (monies.Select(x=>x.Currency).Distinct().Count()>1)
                throw new ArgumentException("All monies are not in the same currency.");


            return new Money
            {
                Amount = monies.Max(x => x.Amount),
                Currency = monies.FirstOrDefault().Currency
            };
        }
    }
}