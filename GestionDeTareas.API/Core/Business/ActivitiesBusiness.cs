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

        public async Task<Response<IEnumerable<ActivityDto>>> GetActivitiesAsync(bool listEntity)
        {
            try
            {
                var activityList = await _unitOfWork.ActivitiesRepository.GetAllAsync(listEntity);

                if (activityList.Count() == 0)
                {
                    return null;
                }

                var activitiesDtoList = activityList.Select(_entityMapper.ActivityToActivityDto)
                                                                  .ToList();

                //var activitiesDtoList = new List<ActivityDto>();

                //foreach (var activity in activityList)
                //{
                //    activitiesDtoList.Add(_entityMapper.ActivityToActivityDto(activity));
                //}

                return new Response<IEnumerable<ActivityDto>>(activitiesDtoList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response<ActivityDto>> GetActivityAsync(int id)
        {
            var activity = await _unitOfWork.ActivitiesRepository.GetByIdAsync(id);
            if (activity == null || activity.IsDeleted == true)
            {
                return new Response<ActivityDto>(null, false, null, "Not Found");
            }
            return new Response<ActivityDto>(_entityMapper.ToActivityDto(activity));
        }

        public async Task<Response<InsertActivityDto>> InsertActivityAsync(InsertActivityDto entity)
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
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response<UpdateActivityDto>> UpdateActivityAsync(UpdateActivityDto data, int id)
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
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Response<string>> DeleteAsync(int id)
        {
            try
            {
                var activity = await _unitOfWork.ActivitiesRepository.GetByIdAsync(id);

                if (activity == null)
                {
                    return new Response<string>(null, false, null, "Activity Not Found");
                }

                await _unitOfWork.ActivitiesRepository.DeleteAsync(id);

                _unitOfWork.SaveChanges();

                return new Response<string>(null, true, null, "Activity Deleted");
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}
