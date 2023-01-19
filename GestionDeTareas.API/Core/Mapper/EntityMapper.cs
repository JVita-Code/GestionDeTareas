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
            //Id = dto.Id ?? 0,
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

    public Activity ToEntity(Activity activity, UpdateActivityDto updateDto)
    {
        activity.Title = updateDto.Title ?? activity.Title;
        activity.Description = updateDto.Description ?? activity.Description;
        activity.IsCompleted = updateDto.IsCompleted;
        activity.IsDeleted = updateDto.IsDeleted;
        activity.ModifiedAt = updateDto.ModifiedAt ?? DateTime.UtcNow;
        activity.CompletedAt = updateDto.CompletedAt ?? activity.CompletedAt;

        return activity;
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

    public ActivityDto ActivityToActivityDto(Activity activity)
    {
        return new ActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            CompletedAt = activity.CompletedAt
        };
    }
}
