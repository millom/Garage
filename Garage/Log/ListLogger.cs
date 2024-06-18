using Garage.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Log
{
    internal class ListLogger(
        IUI ui,
        IList<string> logList)
        : ILogger
    {
        private IUI _ui = ui;
        private readonly IList<string> _logList = logList;

        public void AddToLog(string message)
        {
            _logList.Add(message);
        }

        public void PrintLog()
        {
            _ui.WriteLine("Print log");
            _ui.WriteSpaceLine();
            _logList
                .ToList()
                .ForEach(log => _ui.WriteLine(log));
            _ui.WriteSpaceLine();
        }
    }
}
