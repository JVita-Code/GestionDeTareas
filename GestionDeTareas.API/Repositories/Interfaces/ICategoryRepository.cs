namespace GestionDeTareas.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> ExistsByTitle(string name);
    }
}
