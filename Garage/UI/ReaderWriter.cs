using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("Garage.Test")]
namespace Garage.UI
{
    public class ReaderWriter(IUI ui) : IReaderWriter
    {
        private readonly IUI _ui = ui;

        public void Clear() =>_ui.Clear();

        public string? ReadLine() => _ui.ReadLine();

        public void Write(string line) => _ui.Write(line);

        public void WriteLine(string line) => _ui.WriteLine(line);

        public void WriteMarker() => _ui.Write("> ");

        public void WriteSpaceLine() => _ui.WriteLine("------------------------");
    }
}