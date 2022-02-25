using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.Domain.Enums
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoesNotMatch,
        EmailAlreadyExists,
        UserNameAlreadyExists
    }
}
