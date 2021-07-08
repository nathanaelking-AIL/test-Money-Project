using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MoneyModule.Core.Domain;

namespace MoneyModule.Core.Calculators
{
    public class MoneyCalculatorTests
    {
        [Fact]
        public void ShouldFindTheLargestAmountIfSameCurrency()
        {
            //arrange
            IEnumerable<IMoney> monies = new Money[]
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

        [Fact]
        public void ShouldThrowExceptionWhenFindTheLargestAmountIfDistinctCurrency()
        {
            //arrange
            IEnumerable<IMoney> monies = new Money[]
            {
                new Money() { Amount = 30.0m, Currency = "GBP" },
                new Money() { Amount = 12.8m, Currency = "USD" }
            };

            var calculator = new MoneyCalculator();

            //Assert
            Assert.Throws<ArgumentException>(() => calculator.Max(monies));
        }
    }
}
