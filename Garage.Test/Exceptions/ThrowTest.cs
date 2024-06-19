using Garage.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Test.Exceptions
{
    public class ThrowTest
    {
        [Fact]
        public void GivenExpectedMessage_WhenExecuteIfTrue_ThenThrowExpectedException()
        {
            // Arrange
            var expectedMessage = "MEESAGE";

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => Throw<ArgumentException>.If(true, expectedMessage)
            );

            // Assert
            Assert.Equal( expectedMessage, ex.Message );
        }

        [Fact]
        public void GivenExpectedMessage_WhenExecuteIfWithFalse_ThenNoThrownException()
        {
            // Arrange
            var expectedMessage = "NOT NEEDED";

            // Act & Assert that nothing happens
            Throw<ArgumentException>.If(false, expectedMessage);
        }
    }
}
