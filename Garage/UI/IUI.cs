﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    internal interface IUI
    {
        void Write(string line);
        void WriteLine(string line);
        string ReadLine();
        void Clear();
    }
}
