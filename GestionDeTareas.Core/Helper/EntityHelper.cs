//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;

//namespace GestionDeTareas.API.Core.Helper
//{
//    public static class EntityHelper
//    {
//        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query,
//            params Expression<Func<TEntity, object>>[] includes) where TEntity : class
//        {
//            if (includes != null)
//            {
//                query = includes.Aggregate(query,
//                    (current, include) => current.Include(include));
//            }

//            return query;
//        }
//    }
//}
