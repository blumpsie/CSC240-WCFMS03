using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS03
{
    class CannotRemoveException : System.Exception
    {
        public CannotRemoveException() : base("Could not remove the object") {}

        public CannotRemoveException(string theClass) : base("\nCannotRemoveException thrown.\n"
                                                            + "The " + theClass + "you specified does not exist.") { }
    }
}
