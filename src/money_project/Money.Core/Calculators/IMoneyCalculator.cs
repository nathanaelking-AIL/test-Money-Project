using MoneyModule.Core.Domain;
using System.Collections.Generic;

namespace MoneyModule.Core.Calculators
{
    public interface IMoneyCalculator
    {
        Money Max(IEnumerable<IMoney> monies);
        IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);
    }
}