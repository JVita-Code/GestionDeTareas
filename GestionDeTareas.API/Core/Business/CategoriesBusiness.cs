using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Repositories.Interfaces;
using GestionDeTareas.API.Core.Models.DTOs.Category;

namespace GestionDeTareas.API.Core.Business
{
    public class CategoriesBusiness : ICategoriesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;

        public CategoriesBusiness(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
        }

        public async Task<Response<IEnumerable<CategoryDto>>> GetCategoriesAsync(bool listEntity)
        {
            try
            {
                IEnumerable<Entities.Category> categoryList = await _unitOfWork.CategoriesRepository.GetAllAsync(listEntity);

                if (categoryList.Count() == 0)
                {
                    return new Response<IEnumerable<CategoryDto>>(null, false, null, "Table is Empty.");
                }

                var categoriesDtoList = categoryList.Select(_entityMapper.ToCategoryDto).ToList();

                return new Response<IEnumerable<CategoryDto>>(categoriesDtoList);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<CategoryDto>>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }

        public async Task<Response<CategoryDto>> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<CategoryDto>> InsertCategoryAsync(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<CategoryDto>> UpdateCategoryAsync(CategoryDto entity, int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Response<string>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
