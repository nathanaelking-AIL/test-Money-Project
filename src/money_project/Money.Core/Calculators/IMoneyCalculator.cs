using MoneyModule.Core.Domain;
using System.Collections.Generic;

namespace MoneyModule.Core.Calculators
{
    public interface IMoneyCalculator
    {
        IMoney Max(IEnumerable<IMoney> monies);
        IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);
    }
}