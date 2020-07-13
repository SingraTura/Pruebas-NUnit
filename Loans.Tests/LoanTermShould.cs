using Loans.Domain.Applications;
using NUnit.Framework;

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
    }
}
