using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFirstActivity.Helpers
{
    public class UserAuthorization
    {
        public enum roles
    {
        Administrator,
        Student,
        School
    }

    public const roles rol_predeterminado = roles.Student;
    }
}