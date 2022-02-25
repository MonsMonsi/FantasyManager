using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Domain.Exceptions
{
    public class InvalidUserNameException : Exception
    {
        public string UserName { get; set; }

        public InvalidUserNameException(string userName)
        {
            UserName = userName;
        }

        public InvalidUserNameException(string? message, string userName) : base(message)
        {
            UserName = userName;
        }

        public InvalidUserNameException(string? message, Exception? innerException, string userName) : base(message, innerException)
        {
            UserName = userName;
        }
    }
}
