using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Category;
using GestionDeTareas.API.Repositories.Interfaces;

namespace GestionDeTareas.API.Core.Business
{
    public class CategoriesBusiness : ICategoriesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesBusiness(IUnitOfWork unitOfWork, IEntityMapper entityMapper, ICategoryRepository _categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
            this._categoryRepository = _categoryRepository;
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
            Response<CategoryDto> CategoryDtoresponse = new Response<CategoryDto>();
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);

                if (category == null)
                {
                    return new Response<CategoryDto>(null, false, null, "Category not found.");
                }

                if (category.IsDeleted)
                {
                    return new Response<CategoryDto>(null, false, null, "Category is deleted.");
                }

                return new Response<CategoryDto>(_entityMapper.ToCategoryDto(category));
            }
            catch (Exception ex)
            {
                return new Response<CategoryDto>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }

        public async Task<Response<CategoryDto>> InsertCategoryAsync(CategoryDto entity)
        {
            try
            {
                var category = _entityMapper.ToEntity(entity);

                if (await _categoryRepository.ExistsByTitle(entity.Name))
                {
                    return new Response<CategoryDto>(null, false, null, "A category already exists with that name.");
                }

                await _unitOfWork.CategoriesRepository.AddAsync(category);

                await _unitOfWork.SaveChangesAsync();

                return new Response<CategoryDto>(_entityMapper.ToCategoryDto(category));
            }
            catch (Exception ex)
            {
                return new Response<CategoryDto>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }

        public async Task<Response<CategoryDto>> UpdateCategoryAsync(CategoryDto entity, int id)
        {
            try
            {
                var oldCategory = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);

                if (oldCategory == null || oldCategory.IsDeleted == true)
                {
                    return new Response<CategoryDto>(null, false, null, "Not Found");
                }

                var updatedActivity = _entityMapper.ToEntity(oldCategory, entity);

                await _unitOfWork.CategoriesRepository.Update(oldCategory);

                _unitOfWork.SaveChanges();

                return new Response<CategoryDto>(_entityMapper.ToDto(oldCategory));
            }
            catch (Exception ex)
            {
                return new Response<CategoryDto>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }
        public async Task<Response<string>> DeleteAsync(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(id);

                if (category == null)
                {
                    return new Response<string>(null, false, null, "Category not found.");
                }

                if (category.IsDeleted)
                {
                    return new Response<string>(null, false, null, "Category already deleted.");
                }

                bool deleted = await _unitOfWork.CategoriesRepository.Delete(category);

                _unitOfWork.SaveChanges();

                return new Response<string>(null, true, null, "Category deleted.");
            }
            catch (Exception ex)
            {
                return new Response<string>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }
    }
}
