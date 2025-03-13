using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulation.Test
{
    public class StringOperationTest
    {
        [Fact(Skip = "Esta prueba no es válida en este momento. Ticket No.001")]
        public void ConcatenateStrings()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.ConcatenateStrings("Hello", "World");

            // Assert
            Assert.NotNull(result); // Otros tipos de comparaciones 
            Assert.NotEmpty(result); // Otros tipos de comparaciones
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.IsPalindrome("otra");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.QuantintyInWords("cat", 10);

            // Assert
            Assert.StartsWith("diez", result); // Verifica que la cadena empiece con "diez"
            Assert.Contains("cat", result); // Verifica que la cadena contenga "cat"
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperation = new StringOperations();

            // Verifica que se lance una excepción
            Assert.ThrowsAny<ArgumentNullException>(() => strOperation.GetStringLength(null)); 
        }

        [Theory]
        [InlineData("X", 10)]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            // Arrange
            var strOperation = new StringOperations();

            // Act
            var result = strOperation.FromRomanToNumber(romanNumber);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
