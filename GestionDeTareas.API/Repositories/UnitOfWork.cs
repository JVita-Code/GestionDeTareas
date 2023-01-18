using GestionDeTareas.API.DataAccess;
using GestionDeTareas.API.Entities;
using GestionDeTareas.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDeTareas.API.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;

        private readonly GestorContext _context;
        private readonly IRepository<Activity> _activitiesRepository;

        public UnitOfWork(GestorContext context)
        {
            _context = context;
        }

        public IRepository<Activity> ActivitiesRepository => _activitiesRepository ?? new Repository<Activity>(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
