using System;
using System.Collections.Generic;
using System.Text;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.ApiModels;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.Data.Repositories
{
    public class ItemRepository : EntityRepository<ItemDbModel>, IItemRepository
    {
        public ItemRepository(OssDbContext dbContext) : base(dbContext)
        {
        }
    }
}
