using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.DbModels;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.Data.Repositories
{
    public class UserRepository : BaseEntityRepository<UserDbModel>, IUserRepository
    {
        public UserRepository(OssDbContext dbContext) : base(dbContext)
        {
        }
    }
}