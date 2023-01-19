using GestionDeTareas.API.Core.Helper;
using GestionDeTareas.API.DataAccess;
using GestionDeTareas.API.Entities;
using GestionDeTareas.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionDeTareas.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly GestorContext _context;
        protected DbSet<T> _entities;

        public Repository(GestorContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool listEntity)
        {
            return await _entities.Where(e => e.IsDeleted == (listEntity ? false : true)).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] include)
        {
            if (predicate == null)
            {
                return await _entities.IncludeMultiple(include).ToListAsync();
            }

            return await _entities.Where(predicate).IncludeMultiple(include).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _entities.SingleOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task<T> GetByIdAsync(int id, string include)
        {
            var entity = await _entities
                .Include(include)
                .SingleOrDefaultAsync(x => x.Id == id);

            return entity?.IsDeleted == false ? entity : null;
        }        

        public async Task<T> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }

        public async Task<int> Count()
        {
            return await _entities.CountAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            entity.IsDeleted = true;
            _entities.Update(entity);

            return true;
        }

        public async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> expression)
        {
            var collection = await _entities.Where(expression).ToListAsync();

            return collection;
        }
        
        public async Task<T> Update(T entity)
        {
            _entities.Update(entity);

            return entity;
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            IList<Expression<Func<T, object>>> includes = null, int? page = null, int? pageSize = null)
        {
            var query = this._entities.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync();
        }
    }
}
