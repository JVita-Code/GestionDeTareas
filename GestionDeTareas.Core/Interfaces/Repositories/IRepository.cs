using GestionDeTareas.API.Entities;
using System.Linq.Expressions;

namespace GestionDeTareas.API.Repositories.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync(bool listEntity);

        //Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(int id, string include);

        Task<T> AddAsync(T entity);

        Task<bool> Delete(T entity);


        Task<T> Update(T entity);

        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> expression);

        Task<int> Count();

        //Task<ICollection<T>> FindAllAsync(
        //     Expression<Func<T, bool>> filter = null,
        //     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //     IList<Expression<Func<T, object>>> includes = null,
        //     int? page = null,
        //     int? pageSize = null);
    }
}
