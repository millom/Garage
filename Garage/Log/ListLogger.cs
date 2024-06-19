using Garage.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Log
{
    internal class ListLogger(
        IReaderWriter rw,
        IList<string> logList)
        : IMyLogger
    {
        private IReaderWriter _rw = rw;
        private readonly IList<string> _logList = logList;

        public void AddToLog(string message)
        {
            _logList.Add(message);
        }

        public void PrintLog()
        {
            _rw.WriteLine("Print log");
            _rw.WriteSpaceLine();
            _logList
                .ToList()
                .ForEach(log => _rw.WriteLine(log));
            _rw.WriteSpaceLine();
        }
    }
}
