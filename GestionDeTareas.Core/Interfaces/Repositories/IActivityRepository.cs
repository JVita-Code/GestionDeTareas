namespace GestionDeTareas.API.Repositories.Interfaces
{
    public interface IActivityRepository
    {
        Task<bool> ExistsByTitle(string title);
    }
}