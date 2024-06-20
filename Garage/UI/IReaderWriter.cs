//using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.UI
{
    /// <summary>
    /// An interface defining the class of type ReaderWriter
    /// </summary>
    public interface IReaderWriter
    {
        /// <summary>
        /// As Console.Write, write without end of line
        /// </summary>
        /// <param name="line"></param>
        void Write(string line);

        /// <summary>
        /// As Console.WriteLine, write with end of line
        /// </summary>
        /// <param name="line"></param>
        void WriteLine(string line);

        /// <summary>
        /// Write a line using WriteLine
        /// </summary>
        void WriteSpaceLine();

        /// <summary>
        /// Write a marker using Write
        /// </summary>
        void WriteMarker();

        /// <summary>
        /// As Console.ReadLine, read a line
        /// </summary>
        /// <returns></returns>
        string? ReadLine();

        /// <summary>
        /// As Console.Clear, clear the screen
        /// </summary>
        void Clear();
    }
}
