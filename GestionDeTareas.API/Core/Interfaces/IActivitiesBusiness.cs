using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Activity;

namespace GestionDeTareas.API.Core.Interfaces
{
    public interface IActivitiesBusiness
    {
        Task<Response<InsertActivityDto>> InsertActivity(InsertActivityDto entity);
        Task<Response<ActivityDto>> UpdateActivity(UpdateActivityDto entity, int id);
    }
}
