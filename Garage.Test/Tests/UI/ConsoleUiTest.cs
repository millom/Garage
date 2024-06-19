using Garage.UI;

using Moq;

namespace Garage.Test.Tests.UI
{
    public class ConsoleUiTest
    {
        [Fact]
        public void WriteMarker_GivenExpectedMessage_WhenWriteMarker_ThenParamIsExpected()
        {
            // Arrange
            string expectedMessage = "> ";
            var ui = new Mock<IUI>();
            IReaderWriter rw = new ReaderWriter(ui.Object);

            // Act
            rw.WriteMarker();

            // Assert
            ui.Verify(m => m.Write(It.Is<string>(s => s == expectedMessage)));
        }

        [Fact]
        public void WriteSpaceLine_GivenExpectedMessage_WhenWriteSpaceLine_ThenParamIsExpected()
        {
            // Arrange
            string expectedMessage = "------------------------";
            var ui = new Mock<IUI>();
            IReaderWriter rw = new ReaderWriter(ui.Object);

            // Act
            rw.WriteSpaceLine();

            // Assert
            ui.Verify(m => m.WriteLine(It.Is<string>(s => s == expectedMessage)));
        }
    }
}
