using GestionDeTareas.API.Core.Models.DTOs.Activity;
using GestionDeTareas.API.Entities;

namespace GestionDeTareas.API.Core.Interfaces
{
    public interface IEntityMapper
    {
        Activity ToEntity(ActivityDto dto);
        Activity ToEntity(InsertActivityDto insertDto);
        //Activity ToEntity(UpdateActivityDto updateDto);
        Activity ToEntity(Activity activity, UpdateActivityDto updateDto);
        ActivityDto ToActivityDto(Activity activity);
        InsertActivityDto ToInsertDto(Activity activity);
        UpdateActivityDto ToUpdateDto(Activity activity);

    }
}