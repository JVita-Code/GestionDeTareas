using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using GestionDeTareas.API.Repositories.Interfaces;

namespace GestionDeTareas.API.Core.Business
{
    public class ActivitiesBusiness : IActivitiesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _entityMapper;

        public ActivitiesBusiness(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
        }

        public async Task<Response<InsertActivityDto>> InsertActivity(InsertActivityDto entity)
        {
            //var result = new Response<ActivityDto>();

            try
            {
                var activity = _entityMapper.ToEntity(entity);

                await _unitOfWork.ActivitiesRepository.AddAsync(activity);

                await _unitOfWork.SaveChangesAsync();

                var activityOut = _entityMapper.ToInsertDto(activity);

                return new Response<InsertActivityDto>(activityOut);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<ActivityDto>> UpdateActivity(UpdateActivityDto data, int id)
        {
            try
            {
                var activity = await _unitOfWork.ActivitiesRepository.GetByIdAsync(id);

                if (activity == null || activity.IsDeleted == true)
                {
                    return new Response<ActivityDto>(null, false, null, "Not Found");
                }

                activity = _entityMapper.ToEntity(data);

                activity.Id = id;

                await _unitOfWork.ActivitiesRepository.Update(activity);

                _unitOfWork.SaveChanges();

                var result = _entityMapper.ToActivityDto(activity);

                return new Response<ActivityDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
