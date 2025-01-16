using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoLive.UniTests;

namespace DemoLive.UniTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        // Test pour vérifier que la méthode Add retourne correctement la somme de deux nombres
        [TestMethod]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange & Act
            double result = calculator.Add(10, 5);  // Appel de la méthode Add avec 10 et 5

            // Assert
            Assert.AreEqual(15, result);  // Vérification que le résultat est bien égal à 15 (10 + 5)
        }

        // Test pour vérifier que la méthode Subtract retourne correctement la différence de deux nombres
        [TestMethod]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            // Arrange & Act
            double result = calculator.Subtract(10, 5);  // Appel de la méthode Subtract avec 10 et 5

            // Assert
            Assert.AreEqual(5, result);  // Vérification que le résultat est bien égal à 5 (10 - 5)
        }

        // Test pour vérifier que la méthode Multiply retourne correctement le produit de deux nombres
        [TestMethod]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            // Arrange & Act
            double result = calculator.Multiply(10, 5);  // Appel de la méthode Multiply avec 10 et 5

            // Assert
            Assert.AreEqual(50, result);  // Vérification que le résultat est bien égal à 50 (10 * 5)
        }

        // Test pour vérifier que la méthode Divide retourne correctement le quotient de deux nombres
        [TestMethod]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            // Arrange & Act
            double result = calculator.Divide(10, 5);  // Appel de la méthode Divide avec 10 et 5

            // Assert
            Assert.AreEqual(2, result);  // Vérification que le résultat est bien égal à 2 (10 ÷ 5)
        }

        // Test pour vérifier que la méthode Divide lance bien une exception DivideByZeroException lorsqu'on divise par zéro
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]  // Attente d'une exception DivideByZeroException
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            // Arrange & Act
            calculator.Divide(10, 0);  // Tentative de division par zéro, qui doit lancer une exception
        }
    }
}
