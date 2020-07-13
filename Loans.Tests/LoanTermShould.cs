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
    }
}
