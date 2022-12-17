using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zip.Installments.DAL.Interfaces;

namespace Zip.Installments.DAL.AppContext
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        private readonly OrdersDbContext dbContext;

        public RepositoryBase(OrdersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(T entity)
        {
            await this.dbContext.Set<T>().AddAsync(entity);
            _ = this.dbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> FindAll()
        {
            var resp = await this.dbContext.Set<T>().AsQueryable().ToListAsync();
            return resp;
        }

        public async Task<int> Delete(T entity)
        {
            int ret = 0;
            var record = await this.dbContext.Set<T>().FindAsync(entity);
            if (record != null)
            {
                this.dbContext.Set<T>().Remove(entity);
                ret = await dbContext.SaveChangesAsync();
            }

            return ret;
        }

        public async Task<T> Update(T entity)
        {
            T ret = null;
            var record = await this.dbContext.Set<T>().FindAsync(entity);
            if (record != null)
            {
                this.dbContext.Set<T>().Update(entity);
                ret = record;
            }

            return ret;

        }

        public async Task<IList<T>> FindConditoin(
            Expression<Func<T, bool>> expression)
        {
            return await this.dbContext.Set<T>()
                .Where(expression).ToListAsync();
        }
    }
}
