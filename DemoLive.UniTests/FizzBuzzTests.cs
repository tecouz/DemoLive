using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoLive;

namespace DemoLiveTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [TestInitialize]
        public void Setup()
        {
            _fizzBuzz = new FizzBuzz();
        }

        // Test pour vérifier que la méthode GetOutput lance une exception si la valeur est négative
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]  // Attente d'une exception de type ArgumentException
        public void GetOutput_ShouldThrowArgumentException_WhenValueIsNegative()
        {
            _fizzBuzz.GetOutput(-1);  // Appel de la méthode avec une valeur négative
        }

        // Test paramétré pour vérifier que la méthode retourne une valeur attendue selon les multiples de 3 et 5
        [TestMethod]
        [DataRow(15, "FizzBuzz")]
        [DataRow(30, "FizzBuzz")]
        [DataRow(9, "Fizz")]
        [DataRow(27, "Fizz")]
        [DataRow(10, "Buzz")]
        [DataRow(25, "Buzz")]
        [DataRow(7, "7")]
        [DataRow(8, "8")]
        [DataRow(11, "11")]
        public void GetOutput_ShouldReturnExpectedResult_ForVariousValues(int value, string expected)
        {
            // Act
            var result = _fizzBuzz.GetOutput(value);  // Appel de la méthode avec la valeur

            // Assert
            Assert.AreEqual(expected, result);  // Vérification que le résultat est celui attendu
        }
    }
}
