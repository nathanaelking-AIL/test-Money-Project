﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Money.Core.Calculators
{
    public class MoneyCalculatorTests
    {
        [Fact]
        public void ShouldFindTheLargestAmountIfSameCurrency()
        {
            //arrange
            IEnumerable<Money> monies = new Money[]
            {
                new Money() { Amount = 30.0m, Currency = "GBP" },
                new Money() { Amount = 12.8m, Currency = "GBP" }
            };

            var calculator = new MoneyCalculator();

            //act
            Money result = calculator.Max(monies);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(30.0m, result.Amount);
        }
    }
}
