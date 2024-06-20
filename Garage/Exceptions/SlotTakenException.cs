using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Exceptions
{
    /// <summary>
    /// Exeption used when a parking slot is taken
    /// </summary>
    /// <param name="message"></param>
    internal class SlotTakenException(string message)
        : Exception(message)
    {
    }
}
