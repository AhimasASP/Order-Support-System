using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using OSS.Data.Interfaces;
using OSS.Model.DbModels;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.Data.Repositories
{
    public class ImageRepository : BaseEntityRepository<ImageDbModel>, IImageRepository
    {
        public ImageRepository(OssDbContext dbContext) : base(dbContext)
        {
        }
    }
}