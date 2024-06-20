using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Exceptions
{
    /// <summary>
    /// Exeption used when a vehicle is not found
    /// </summary>
    /// <param name="message"></param>
    internal class RegNumberNotFoundException(string message)
        : Exception(message)
    {
    }
}
