using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DemoLive.Tests
{
    [TestClass]
    public class DateValidatorTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowException_WhenNumberOfDashesIsIncorrect()
        {
            // Arrange
            string invalidDate = "31-12"; // Date avec un nombre de tirets incorrect

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new DateValidator(invalidDate));
        }

        [TestMethod]
        public void IsValid_ShouldReturnTrue_ForValidDate()
        {
            // Arrange
            string validDate = "31-12-2023";
            var validator = new DateValidator(validDate);

            // Act
            var result = validator.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_ForInvalidDay()
        {
            // Arrange
            string invalidDate = "32-12-2023"; // Jour invalide
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.IsValid();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_ForInvalidMonth()
        {
            // Arrange
            string invalidDate = "31-13-2023"; // Mois invalide
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.IsValid();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_ForInvalidYear()
        {
            // Arrange
            string invalidDate = "31-12-1999"; // Année invalide
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.IsValid();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckNumberOfDashes_ShouldReturnTrue_WhenDashesAreCorrect()
        {
            // Arrange
            string validDate = "31-12-2023";
            var validator = new DateValidator(validDate);

            // Act
            var result = validator.CheckNumberOfDashes();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckAllNumbersAreIntegers_ShouldReturnFalse_WhenPartsAreNotIntegers()
        {
            // Arrange
            string invalidDate = "31-AB-2023"; // Mois non entier
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.CheckAllNumbersAreIntegers();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckDayNumber_ShouldReturnFalse_ForInvalidDay()
        {
            // Arrange
            string invalidDate = "32-12-2023"; // Jour invalide
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.CheckDayNumber();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckMonthNumber_ShouldReturnFalse_ForInvalidMonth()
        {
            // Arrange
            string invalidDate = "31-13-2023"; // Mois invalide
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.CheckMonthNumber();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckYearNumber_ShouldReturnFalse_ForInvalidYear()
        {
            // Arrange
            string invalidDate = "31-12-1999"; // Année invalide
            var validator = new DateValidator(invalidDate);

            // Act
            var result = validator.CheckYearNumber();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ThrowExceptionIfNumbersAreNotIntegers_ShouldThrowException_WhenPartsAreNotIntegers()
        {
            // Arrange
            string invalidDate = "31-AB-2023"; // Mois non entier
            var validator = new DateValidator(invalidDate);

            // Act & Assert
            Assert.ThrowsException<InvalidCastException>(() => validator.ThrowExceptionIfNumbersAreNotIntegers());
        }
    }
}
