//using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.UI
{
    public interface IReaderWriter
    {
        void Write(string line);
        void WriteLine(string line);
        void WriteSpaceLine();
        void WriteMarker();
        string? ReadLine();
        void Clear();
    }
}
