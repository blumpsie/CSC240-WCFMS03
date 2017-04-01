using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS03
{
    class DuplicateObjectException : System.Exception
    {
        public DuplicateObjectException() : base("The object already exists.") { }
           
        public DuplicateObjectException(string theClass) : base("\nDuplicateObjectException throown.\n"
                                                                + "The " + theClass + " you specified already exists.") { }
    }
}
