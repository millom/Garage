using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Exceptions
{
    internal class RegNumberNotFoundException(string message)
        : Exception(message)
    {
    }
}
