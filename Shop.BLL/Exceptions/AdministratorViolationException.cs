using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Exceptions
{
    public class AdministratorViolationException : Exception
    {
        public AdministratorViolationException()
        {
        }

        public AdministratorViolationException(string message)
            : base(message)
        {
        }

        public AdministratorViolationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
