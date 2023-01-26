using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTareas.API.Core.Interfaces
{
    public interface IActivitiesBusiness
    {
        Task<Response<IEnumerable<ActivityDto>>> GetActivitiesAsync(bool listEntity);
        Task<Response<ActivityDto>> GetActivityAsync(int id);
        Task<Response<InsertActivityDto>> InsertActivityAsync(InsertActivityDto entity);
        Task<Response<UpdateActivityDto>> UpdateActivityAsync(UpdateActivityDto entity, int id);
        Task<Response<string>> DeleteAsync(int id);
    }
}
