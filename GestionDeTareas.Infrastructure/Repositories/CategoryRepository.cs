using GestionDeTareas.API.DataAccess;
using GestionDeTareas.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GestorContext _dbcontext;

        public CategoryRepository(GestorContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> ExistsByTitle(string name)
        {
            return await _dbcontext.Categories.AnyAsync(c => c.Name == name);
        }
    }
}
