using System;

namespace FileReading.Core
{
    public class Roles
    {
        [Flags]
        public enum RolesEnum
        {
            Admin,
            SimpleUser
        }

    }
}
