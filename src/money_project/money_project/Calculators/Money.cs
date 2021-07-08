using System;
using System.Collections.Generic;
using System.Text;

namespace Money.Core.Calculators
{
    public class Money
    {
        public decimal Amount { get; internal set; }
        public string Currency { get; internal set; }
    }
}
