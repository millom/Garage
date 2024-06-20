using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.UI
{
    /// <summary>
    /// An intefacee
    /// </summary>
    public interface IUI
    {
        /// <summary>
        /// Define method like Console.Write
        /// </summary>
        /// <param name="line"></param>
        void Write(string line);

        /// <summary>
        /// Define method like Console.WriteLine
        /// </summary>
        /// <param name="line"></param>
        void WriteLine(string line);

        /// <summary>
        /// Define method like Console.ReadLine
        /// </summary>
        string? ReadLine();

        /// <summary>
        /// Define method like Console.Clear
        /// </summary>
        void Clear();
    }
}
