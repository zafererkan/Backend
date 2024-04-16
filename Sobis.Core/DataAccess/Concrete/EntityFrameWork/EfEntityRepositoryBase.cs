using Microsoft.EntityFrameworkCore;
using Sobis.Core.DataAccess.Abstract;
using Sobis.Core.Entities.Abstract;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sobis.Core.DataAccess.Concrete.EntityFrameWork
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        #region Normal Metotlar
        public bool Add(TEntity entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Added;
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool AddBulk(IEnumerable<TEntity> entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                var entry = context.Entry(entity);

                context.AddRange(entity);
                //entry.State = EntityState.Added;
                result = context.SaveChanges() > 0;
            }
            return result;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (DbContext context = new TContext())
            {
                return context.Set<TEntity>().AsNoTracking().FirstOrDefault(Filter);
            }
        }
        public bool Update(TEntity entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Modified;
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool UpdateBulk(IEnumerable<TEntity> entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                //var entry = context.Entry(entity);
                //entry.State = EntityState.Modified;
                context.UpdateRange(entity);
                result = context.SaveChanges() > 0;
            }
            return result;
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (DbContext context = new TContext())
            {
                return Filter != null
                    ? context.Set<TEntity>().AsNoTracking().Where(Filter).ToList()
                    : context.Set<TEntity>().AsNoTracking().ToList();
            }
        }
        public bool Delete(TEntity entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Deleted;
                result = context.SaveChanges() > 0;
            }
            return result;
        }
        public bool DeleteBulk(IEnumerable<TEntity> entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                //var entry = context.Entry(entity);
                //entry.State = EntityState.Deleted;
                context.RemoveRange(entity);
                result = context.SaveChanges() > 0;
            }
            return result;
        }
        public bool HardDelete(TEntity entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                var entry = context.Entry(entity);
                entry.State = EntityState.Deleted;
                //context.RemoveRange(entity);
                result = context.SaveChanges() > 0;
            }
            return result;
        }
        public bool HardDeleteBulk(IEnumerable<TEntity> entity)
        {
            bool result = false;
            using (DbContext context = new TContext())
            {
                //var entry = context.Entry(entity);
                //entry.State = EntityState.Deleted;
                context.RemoveRange(entity);
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        #endregion

        #region Asenkron Metotlar

        public virtual async Task<IResult> AddAsync(TEntity entity)
        {
            using (DbContext context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return new SuccessResult("Add process successful");
            }
        }
        public async Task<IResult> AddBulkAsync(IEnumerable<TEntity> entity)
        {
            using (DbContext context = new TContext())
            {
                await context.AddRangeAsync(entity);
                await context.SaveChangesAsync();
                return new SuccessResult("Bulk add process successful");
            }
        }

        public virtual async Task<IResult> UpdateAsync(TEntity entity)
        {
            using (DbContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);

                await context.SaveChangesAsync();
                return new SuccessResult("Update process successful.");
            }
        }
        public async Task<IResult> UpdateBulkAsync(IEnumerable<TEntity> entity)
        {

            using (DbContext context = new TContext())
            {
                context.UpdateRange(entity);
                await context.SaveChangesAsync();
                return new SuccessResult("Bulk update process successful.");
            }
        }

        public virtual async Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> Filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (DbContext context = new TContext())
            {
                var result = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(Filter);
                return new SuccessDataResult<TEntity>(result);
            }
        }
        public virtual async Task<IDataResult<IEnumerable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> Filter = null,
            params Expression<Func<TEntity, object>>[] includeProperties
            )
        {
            using (DbContext context = new TContext())
            {

                IQueryable<TEntity> Query = context.Set<TEntity>();
                if (Filter != null)
                {
                    Query = Query.Where(Filter);
                }

                foreach (var includeProperty in includeProperties)
                {

                    Query = Query.Include(includeProperty);
                }
                
                var result = await Query.AsNoTracking().ToListAsync();
                return new SuccessDataResult<IEnumerable<TEntity>>(result);
            }
        }

        public virtual IQueryable<TEntity> GetAllByFilter(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using (DbContext context = new TContext())
            {
                IQueryable<TEntity> Query = context.Set<TEntity>();

                foreach (var includeProperty in includeProperties)
                {
                    Query = Query.Include(includeProperty);
                }
                return Query.AsNoTracking().AsQueryable();
            }
        }

        public virtual async Task<IResult> DeleteAsync(TEntity entity)
        {

            using (DbContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return new SuccessResult("Delete process successful");
            }
        }
        public async Task<IResult> DeleteBulkAsync(IEnumerable<TEntity> entity)
        {
            using (DbContext context = new TContext())
            {
                context.RemoveRange(entity);
                await context.SaveChangesAsync();
                return new SuccessResult("Bulk delete process successful.");
            }
        }
        #endregion


    }
}
