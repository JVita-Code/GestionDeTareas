using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using GestionDeTareas.API.Core.Models.DTOs.Category;
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
            DeletedAt = dto.DeletedAt,
            CategoryId = dto.CategoryId,
        };
    }

    public Activity ToEntity(InsertActivityDto insertDto)
    {
        return new Activity
        {
            Title = insertDto.Title,
            Description = insertDto.Description,
            IsCompleted = insertDto.IsCompleted,
            CategoryId = insertDto.CategoryId
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
        activity.CategoryId = updateDto.CategoryId;

        return activity;
    }

    public ActivityDto ToActivityDto(Activity activity)
    {
        return new ActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            CompletedAt = activity.CompletedAt,
            CategoryId = activity.CategoryId,
            ModifiedAt = activity.ModifiedAt
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
            CategoryId = activity.CategoryId
        };
    }

    public UpdateActivityDto ToUpdateDto(Activity activity)
    {
        return new UpdateActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            CompletedAt = activity.CompletedAt,
            CategoryId = activity.CategoryId
        };
    }

    public ActivityDto ActivityToActivityDto(Activity activity)
    {
        return new ActivityDto
        {
            Title = activity.Title,
            Description = activity.Description,
            IsCompleted = activity.IsCompleted,
            CompletedAt = activity.CompletedAt,
            ModifiedAt = activity.ModifiedAt,
        };
    }

    public Category ToEntity(CategoryDto dto)
    {
        return new Entities.Category
        {
            Name = dto.Name,
            Description = dto.Description,
            Activities = dto.Activities
        };
    }

    public Category ToEntity(InsertCategoryDto dto)
    {
        return new Entities.Category
        {
            Name = dto.Name,
            Description = dto.Description,
            ModifiedAt = dto.ModifiedAt ?? DateTime.UtcNow,
        };
    }



    public CategoryDto ToCategoryDto(Category category)
    {
        return new CategoryDto
        {
            Name = category.Name,
            Description = category.Description,
            ModifiedAt = category.ModifiedAt,
        };
    }

    public Category ToEntity(Category category, CategoryDto categoryDto)
    {
        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.Activities = categoryDto.Activities;
        category.ModifiedAt = categoryDto.ModifiedAt ?? DateTime.UtcNow;
        category.IsDeleted = categoryDto.IsDeleted;
        category.DeletedAt = categoryDto.DeletedAt;

        return category;
    }

    public CategoryDto ToDto(Category activity)
    {
        return new CategoryDto
        {
            Name = activity.Name,
            Description = activity.Description
        };
    }
}
