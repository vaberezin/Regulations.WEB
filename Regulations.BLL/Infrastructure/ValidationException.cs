using System;
using System.Collections.Generic;
using System.Text;

namespace Regulations.BLL.Infrastructure
{
    public class ValidationException : Exception  
        //current class serves as the transfer between DAL and Presentation Layer
        //and casts property name between them
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) :base(message)
        {
            Property = prop;
        }
    }
}
