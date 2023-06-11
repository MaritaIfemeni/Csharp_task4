using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Shared
{
    public class ExpectionHandler : Exception
    {
        public ExpectionHandler(string message) : base(message)
        {

        }

    }

}