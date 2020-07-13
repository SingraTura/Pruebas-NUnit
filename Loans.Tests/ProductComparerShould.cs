using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    class ProductComparerShould
    {
        private List<LoanProduct> products;
        private ProductComparer sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.products = new List<LoanProduct>
            {
                new LoanProduct(1,"a", 1),
                new LoanProduct(2,"b", 2),
                new LoanProduct(3,"c", 3)
            };
        }
        [OneTimeTearDown]
        public void OnetTimeTearDown()
        {
            // Runs after each test executes
            // products.Dispose();
        }
        [SetUp]
        public void Setup()
        {
            
            this.sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
        }
        [TearDown]
        public void TearDown()
        {
            // Runs after each test executes
            // sut.Dispose();
        }

        [Test]
        public void ReturnCorrectNumberOfComparisons()
        {
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);
        }
        [Test]
        public void NotReturnUniqComparisons()
        {
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Is.Unique);
        }
        [Test]
        public void ReturnComparisonForFisrtProduct()
        {
            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

            Assert.That(comparisons, Does.Contain(expectedProduct));
        }
        [Test]
        public void ReturnComparisonForFisrtProduct_WithPartialKnownExpectedValues()
        {

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(1)
                        .Matches<MonthlyRepaymentComparison>(
                            item => item.ProductName == "a" &&
                                    item.InterestRate == 1 &&
                                    item.MonthlyRepayment > 0));
        }
    }
}
