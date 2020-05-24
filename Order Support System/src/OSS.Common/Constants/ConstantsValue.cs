using System;
using System.IO;

namespace OSS.Common.Constants
{
    public class ConstantsValue
    {
        public const string DefaultPassword = "Asddsa_123";

        public static readonly string ImagePath = Directory.GetCurrentDirectory() + @"\Images\";
        public static readonly string ImageSeedPath = Directory.GetCurrentDirectory() + @"\tmp\";

        public static class Roles
        {
            public const string Admin = "Admin";

            public const string User = "User";

            public const string AllRoles = "User, Admin";
        }
    }
}