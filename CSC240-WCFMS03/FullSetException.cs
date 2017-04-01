using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS03
{
    class FullSetException : System.Exception
    {
        public FullSetException() : base("The set is full.") { }

        public FullSetException(string theClass) : base("\nFullSetException thrown.\n"
                                                        + "The " + theClass + " could not be added.\n"
                                                        + "The set is full.") { }
    }
}
