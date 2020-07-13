using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    class ProductComparerShould
    {
        [Test]
        public void ReturnCorrectNumberOfComparisons()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a", 1),
                new LoanProduct(2,"b", 2),
                new LoanProduct(3,"c", 3)
            };
            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);
        }
        [Test]
        public void NotReturnUniqComparisons()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a", 1),
                new LoanProduct(2,"b", 2),
                new LoanProduct(3,"c", 3)
            };
            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Is.Unique);
        }
        [Test]
        public void ReturnComparisonForFisrtProduct()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a", 1),
                new LoanProduct(2,"b", 2),
                new LoanProduct(3,"c", 3)
            };
            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

            Assert.That(comparisons, Does.Contain(expectedProduct));
        }
        [Test]
        public void ReturnComparisonForFisrtProduct_WithPartialKnownExpectedValues()
        {
            var products = new List<LoanProduct>
            {
                new LoanProduct(1,"a", 1),
                new LoanProduct(2,"b", 2),
                new LoanProduct(3,"c", 3)
            };
            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            // MAL
            Assert.That(comparisons, Has.Exactly(1)
                .Property("ProductName").EqualTo("a")
                .And
                .Property("InterestRate").EqualTo(1)
                .And
                .Property("MonthlyRepayment").GreaterThan(0));

            // BIEN
            Assert.That(comparisons, Has.Exactly(1)
                        .Matches<MonthlyRepaymentComparison>(
                            item => item.ProductName == "a" &&
                                    item.InterestRate == 1 &&
                                    item.MonthlyRepayment > 0));
        }
    }
}
