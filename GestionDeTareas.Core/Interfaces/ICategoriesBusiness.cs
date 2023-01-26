using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Category;

namespace GestionDeTareas.API.Core.Interfaces
{
    public interface ICategoriesBusiness
    {
        Task<Response<IEnumerable<CategoryDto>>> GetCategoriesAsync(bool listEntity);
        Task<Response<CategoryDto>> GetCategoryAsync(int id);
        //Task<Response<CategoryDto>> InsertCategoryAsync(CategoryDto entity);
        Task<Response<CategoryDto>> InsertCategoryAsync(InsertCategoryDto entity);
        Task<Response<CategoryDto>> UpdateCategoryAsync(CategoryDto entity, int id);
        Task<Response<string>> DeleteAsync(int id);
    }
}