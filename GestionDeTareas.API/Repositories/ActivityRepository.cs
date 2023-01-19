using GestionDeTareas.API.DataAccess;
using GestionDeTareas.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.API.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly GestorContext _dbcontext;

        public ActivityRepository(GestorContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> ExistsByTitle(string title)
        {
            return await _dbcontext.Activities.AnyAsync(c => c.Title == title);
        }
    }
}
