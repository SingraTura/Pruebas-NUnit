using Loans.Domain.Applications;
using NUnit.Framework;
using System.Collections.Generic;

namespace Loans.Tests
{
    [TestFixture]
    class LoanTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            // Arrange
            var sut = new LoanTerm(1);

            // Act
            var monthsYear = sut.ToMonths();

            // Assert
            Assert.That(monthsYear, Is.EqualTo(12)); 
        }
        [Test]
        public void StoreYears()
        {
            // Arrange
            var sut = new LoanTerm(1);

            // Act
            var years = sut.Years;

            // Assert 
            Assert.That(years, Is.EqualTo(1));
        }
        [Test]
        public void RespectValueEquality()
        {
            // Arrange
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            // Act

            // Assert

            Assert.That(a, Is.EqualTo(b));
        }
        [Test]
        public void RespectValueInequality()
        {
            // Arrange
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            // Act

            // Assert

            Assert.That(a, Is.Not.EqualTo(b));
        }
        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;

            Assert.That(a, Is.SameAs(b));

            var x = new List<string> { "a", "b" };
            var y = x;

            Assert.That(x, Is.SameAs(y));
        }
        [Test]
        public void ReferenceNotEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.Not.SameAs(b));

            var x = new List<string> { "a", "b" };
            var y = new List<string> { "a", "b" };

            Assert.That(x, Is.Not.SameAs(y));

        }
        [Test]
        public void Double()
        {
            double a = 1.0 / 3.0;
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }
    }
}
