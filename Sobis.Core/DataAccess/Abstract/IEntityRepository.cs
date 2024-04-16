using Sobis.Core.Entities.Abstract;
using Sobis.Core.Utilities.Results.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> Filter = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter = null);
        bool Add(T entity);
        bool AddBulk(IEnumerable<T> entity);
        bool Update(T entity);
        bool UpdateBulk(IEnumerable<T> entity);
        bool Delete(T entity);
        bool DeleteBulk(IEnumerable<T> entity);
        //Task<IDataResult<IEnumerable<T>>> GetRecordBySqlAsync(string Sql, List<object> parameters);

        ///// <summary>
        ///// Dal Katmanında hem Asenkron hemde normal metotlarla destekliyoruz.
        ///// </summary>
        ///// <param name="Filter"> Entitiden gelen değerlerin null olup olmadığına bakacak ve filtre uygulayacak.</param>
        ///// <param name="includeProperties"></param>
        ///// <returns></returns>
        Task<IDataResult<T>> GetAsync(Expression<Func<T, bool>> Filter, params Expression<Func<T, object>>[] includeProperties);
        Task<IDataResult<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAllByFilter(params Expression<Func<T, object>>[] includeProperties);
        Task<IResult> AddAsync(T entity);
        Task<IResult> AddBulkAsync(IEnumerable<T> entity);
        Task<IResult> UpdateAsync(T entity);
        Task<IResult> UpdateBulkAsync(IEnumerable<T> entity);
        Task<IResult> DeleteAsync(T entity);
        Task<IResult> DeleteBulkAsync(IEnumerable<T> entity);
    }
}
