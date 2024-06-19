using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.UI
{
    public interface IUI
    {
        void Write(string line);
        void WriteLine(string line);
        string? ReadLine();
        void Clear();
    }
}
