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

        public async Task<Response<UpdateActivityDto>> UpdateActivity(UpdateActivityDto data, int id)
        {
            try
            {
                var Oldactivity = await _unitOfWork.ActivitiesRepository.GetByIdAsync(id);

                if (Oldactivity == null || Oldactivity.IsDeleted == true)
                {
                    return new Response<UpdateActivityDto>(null, false, null, "Not Found");
                }

                var updatedActivity = _entityMapper.ToEntity(Oldactivity, data);

                await _unitOfWork.ActivitiesRepository.Update(Oldactivity);

                _unitOfWork.SaveChanges();

                UpdateActivityDto result = _entityMapper.ToUpdateDto(Oldactivity);

                return new Response<UpdateActivityDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
