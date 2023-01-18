using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using GestionDeTareas.API.Entities;

namespace GestionDeTareas.API.Core.Mapper;

public class EntityMapper : IEntityMapper
{
    public Activity ToEntity(ActivityDto dto)
    {
        return new Activity
        {
            Id = dto.Id ?? 0,
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted,
            CompletedAt = dto.CompletedAt,
            ModifiedAt = dto.ModifiedAt,
            IsDeleted = dto.IsDeleted,
            DeletedAt = dto.DeletedAt
        };
    }

    public Activity ToEntity(InsertActivityDto insertDto)
    {
        return new Activity
        {
            Title = insertDto.Title,
            Description = insertDto.Description,
            IsCompleted = insertDto.IsCompleted,
            //CompletedAt = insertDto.CompletedAt
        };
    }

    public Activity ToEntity(UpdateActivityDto updateDto)
    {
        return new Activity
        {
            Id = updateDto.Id,
            Title = updateDto.Title,
            Description = updateDto.Description,
            IsCompleted = updateDto.IsCompleted,
            CompletedAt = updateDto.CompletedAt
        };
    }

    public ActivityDto ToActivityDto(Activity activity)
    {
        return new ActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            CompletedAt = activity.CompletedAt
        };
    }

    public InsertActivityDto ToInsertDto(Activity activity)
    {
        return new InsertActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            //CompletedAt = activity.CompletedAt
        };
    }

    public UpdateActivityDto ToUpdateDto(Activity activity)
    {
        return new UpdateActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            CompletedAt = activity.CompletedAt
        };
    }
}
