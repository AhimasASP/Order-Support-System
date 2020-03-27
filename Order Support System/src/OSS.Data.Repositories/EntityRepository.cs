using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSS.Data.Interfaces;
using OSS.Domain.Common.Models.DbModels;
using OSS.WebApplication.Configurations.Entity;

namespace OSS.Data.Repositories
{
    public class EntityRepository<TModel> : IRepository<TModel> where TModel : BaseDbModel
    {
        private readonly OssDbContext _dbContext;
        private readonly DbSet<TModel> _dbSet;

        public EntityRepository(OssDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TModel>();
        }

        public async Task<List<TModel>> GetListAsync(CancellationToken token)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken: token);
        }

        public async Task<TModel> GetAsync(Guid id, CancellationToken token)
        {
            return await _dbSet.FindAsync(id, token);
        }

        public async Task<string> CreateAsync(TModel model, CancellationToken token)
        {
            await _dbSet.AddAsync(model, token);
            await _dbContext.SaveChangesAsync(token);
            return "Success!";
        }

        public async Task<string> UpdateAsync(TModel model, CancellationToken token)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(token);
            return "Success!";
        }

        public async Task<string> DeleteAsync(TModel model, CancellationToken token)
        {
            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync(token);
            return "Success!";
        }

    }
}
