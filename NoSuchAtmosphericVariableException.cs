using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP
{
    public class NoSuchAtmosphericVariableException : Exception 
    {
        public NoSuchAtmosphericVariableException() : base("Provided type of atmospheric variable doesn't exist") { }
    }
}
