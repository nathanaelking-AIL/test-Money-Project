using MoneyModule.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyModule.Core.Calculators
{
    public class MoneyCalculator
    {
        public MoneyCalculator()
        {
        }

        public Money Max(IEnumerable<IMoney> monies)
        {
            if (monies is null)
                throw new ArgumentNullException("No money list passed in argument.");

            if (monies.Select(x => x.Currency).Distinct().Count() > 1)
                throw new ArgumentException("All monies are not in the same currency.");

            return new Money
            {
                Amount = monies.Max(x => x.Amount),
                Currency = monies.FirstOrDefault().Currency
            };
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            if (monies is null)
                throw new ArgumentNullException("No money list passed in argument.");

            var result = monies
                        .GroupBy(x => x.Currency)
                        .Select(y => new Money()
                        { 
                            Amount = y.Sum(z => z.Amount), 
                            Currency = y.Key 
                        });

            return result;
        }
    }
}