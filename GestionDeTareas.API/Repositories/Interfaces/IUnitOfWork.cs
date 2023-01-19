using GestionDeTareas.API.Entities;

namespace GestionDeTareas.API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Activity> ActivitiesRepository { get; }
        IRepository<Category> CategoriesRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
        void Dispose();
    }
}