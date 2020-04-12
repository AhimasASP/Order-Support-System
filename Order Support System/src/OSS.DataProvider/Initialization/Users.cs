using System.Collections.Generic;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.WebApplication.Configurations.Entity
{
    public class Users
    {
        public readonly List<UserDbModel> users = new List<UserDbModel>()
        {
            new UserDbModel()
            {
                UserName = "Admin",
                FirstName = "Alex",
                LastName = "Dutcher",
                PhoneNumber = "=37529 111 11 11",
                Email = "admin@oss.by",
            },
            new UserDbModel()
            {
                UserName = "Designer",
                FirstName = "Helen",
                LastName = "Golovach",
                PhoneNumber = "=37529 222 22 22",
                Email = "designer@oss.by",
            },
            new UserDbModel()
            {
                UserName = "FirstDesigner",
                FirstName = "Gannet",
                LastName = "D'Ark",
                PhoneNumber = "=37529 444 44 44",
                Email = "first_designer@oss.by",
            },
            new UserDbModel()
            {
                UserName = "Manager",
                FirstName = "Pamela",
                LastName = "Anderson",
                PhoneNumber = "=37529 333 33 33",
                Email = "manager@oss.by",
            }
        };
    }
}