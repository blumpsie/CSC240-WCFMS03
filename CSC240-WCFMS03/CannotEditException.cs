using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS03
{
    class CannotEditException : System.Exception
    {
        public CannotEditException() : base("The object could not be edited.") { }

        public CannotEditException(string theClass) : base("CannotEditException thrown.\n"
                                                            + "The " + theClass + " you specified is not in the set.") { }
    }
}
