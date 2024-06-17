using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    internal class ConsoleUI : IUI
    {
        public string ReadLine() => Console.ReadLine();

        public void Write(string line) => Console.Write(line);

        public void WriteLine(string line) => Console.WriteLine(line);

        public void Clear() => Console.Clear();
    }
}
