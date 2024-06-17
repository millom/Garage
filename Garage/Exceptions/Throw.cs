using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Exceptions
{
    internal class Throw<T> where T : Exception
    {
        public static void If(bool isValid, string message)
        {
            if (!isValid) return;

            Exception? e = Activator.CreateInstance(typeof(T), message) as Exception;
            if (e != null) throw e;

            throw Activator.CreateInstance<T>();
        }
    }
}
