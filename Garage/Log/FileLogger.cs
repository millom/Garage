﻿using Garage.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Log
{
    internal class FileLogger(
        IUI ui,
        IEnumerable<string> logList)
        : ILogger
    {
        private IUI _ui = ui;
        private readonly IEnumerable<string> _logList = logList;

        public void AddToLog() { }
        public void PrintLog() { }
    }
}
