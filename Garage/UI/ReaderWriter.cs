using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.UI
{
    /// <summary>
    /// A wraper class for IUI. simplier to test and has some strings to print
    /// </summary>
    /// <param name="ui"></param>
    public class ReaderWriter(IUI ui) : IReaderWriter
    {
        private readonly IUI _ui = ui;

        /// <summary>
        /// As Console.Clear, clear the screen
        /// </summary>
        public void Clear() =>_ui.Clear();

        /// <summary>
        /// As Console.ReadLine, read a line
        /// </summary>
        /// <returns></returns>
        public string? ReadLine() => _ui.ReadLine();

        /// <summary>
        /// As Console.Write, write without end of line
        /// </summary>
        /// <param name="line"></param>
        public void Write(string line) => _ui.Write(line);

        /// <summary>
        /// As Console.WriteLine, write with end of line
        /// </summary>
        /// <param name="line"></param>
        public void WriteLine(string line) => _ui.WriteLine(line);

        /// <summary>
        /// Write a marker using Write
        /// </summary>
        public void WriteMarker() => Write("> ");

        /// <summary>
        /// Write a line using WriteLine
        /// </summary>
        public void WriteSpaceLine() => WriteLine("------------------------");
    }
}