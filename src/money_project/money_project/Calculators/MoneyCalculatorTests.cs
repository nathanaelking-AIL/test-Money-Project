using MoneyModule.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
                new Money { Amount = 30.0m, Currency = "GBP" },
                new Money { Amount = 12.8m, Currency = "GBP" }
            };

            var calculator = new MoneyCalculator();

            //act
            IMoney result = calculator.Max(monies);

            //assert
            Assert.NotNull(result);
            Assert.Equal(30.0m, result.Amount);
        }

        [Fact]
        public void ShouldThrowExceptionWhenFindTheLargestAmountIfDistinctCurrency()
        {
            //arrange
            IEnumerable<IMoney> monies = new Money[]
            {
                new Money { Amount = 30.0m, Currency = "GBP" },
                new Money { Amount = 12.8m, Currency = "USD" }
            };

            var calculator = new MoneyCalculator();

            //assert
            Assert.Throws<ArgumentException>(() => calculator.Max(monies));
        }

        [Fact]
        public void ShouldThrowNullExceptionWhenFindTheLargestAmountArgumentIsNull()
        {
            //arrange
            var calculator = new MoneyCalculator();
            var message = "No money list passed in argument.";

            //assert
            var exception =Assert.Throws<ArgumentNullException>(
                () => calculator.Max(null));
            Assert.Equal(message, exception.ParamName);
        }

        [Fact]
        public void ShouldReturnSumPerCurrency()
        {
            //arrange
            IEnumerable<IMoney> monies = new Money[]
            {
                new Money { Amount = 30.0m, Currency = "GBP" },
                new Money { Amount = 30.0m, Currency = "GBP" },
                new Money { Amount = 12.8m, Currency = "USD" },
                new Money { Amount = 30.8m, Currency = "USD" },
                new Money { Amount = 16.8m, Currency = "CDN" },
            };

            var calculator = new MoneyCalculator();

            //act
            IEnumerable<IMoney> result = calculator.SumPerCurrency(monies);

            //assert
            Assert.NotNull(result);
            Assert.Equal(60.0m,
                result.FirstOrDefault(x => x.Currency.Equals("GBP")).Amount);
            Assert.Equal(43.6m,
                result.FirstOrDefault(x => x.Currency.Equals("USD")).Amount);
            Assert.Equal(16.8m,
                result.FirstOrDefault(x => x.Currency.Equals("CDN")).Amount);
        }

        [Fact]
        public void ShouldReturnArgumentExceptionIfNullArgumentToSumPerCurrency()
        {
            //arrange
            var calculator = new MoneyCalculator();
            var message = "No money list passed in argument.";

            //assert
            var exception = Assert.Throws<ArgumentNullException>(
                () => calculator.SumPerCurrency(null));
            Assert.Equal(message, exception.ParamName);
        }

    }
}
