using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JardinBotanique.Exceptions
{
    public class RessourcesInsuffisantesException : Exception
    {
        public RessourcesInsuffisantesException(string message) : base(message)
        {
        }

    }
}
