using GestionDeTareas.API.Core.Models.DTOs.Activity;
using GestionDeTareas.API.Core.Models.DTOs.Category;
using GestionDeTareas.API.Entities;

namespace GestionDeTareas.API.Core.Interfaces
{
    public interface IEntityMapper
    {
        Activity ToEntity(ActivityDto dto);
        Activity ToEntity(InsertActivityDto insertDto);
        Activity ToEntity(Activity activity, UpdateActivityDto updateDto);
        ActivityDto ToActivityDto(Activity activity);
        InsertActivityDto ToInsertDto(Activity activity);
        UpdateActivityDto ToUpdateDto(Activity activity);
        ActivityDto ActivityToActivityDto(Activity activity);

        //Type
        Category ToEntity(CategoryDto dto);
        CategoryDto ToCategoryDto(Category dto);
    }
}