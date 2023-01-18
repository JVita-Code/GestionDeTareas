using GestionDeTareas.API.Entities;

namespace GestionDeTareas.API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Activity> ActivitiesRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
        void Dispose();
    }
}