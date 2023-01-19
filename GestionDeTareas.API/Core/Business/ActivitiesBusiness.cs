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
        private readonly IActivityRepository _activityRepository;

        public ActivitiesBusiness(IUnitOfWork unitOfWork, IEntityMapper entityMapper, IActivityRepository activityRepository)
        {
            _unitOfWork = unitOfWork;
            _entityMapper = entityMapper;
            _activityRepository = activityRepository;
        }        

        public async Task<Response<IEnumerable<ActivityDto>>> GetActivitiesAsync(bool listEntity)
        {
            try
            {
                var activityList = await _unitOfWork.ActivitiesRepository.GetAllAsync(listEntity);

                if (activityList.Count() == 0)
                {
                    return new Response<IEnumerable<ActivityDto>>(null, false, null, "Table is Empty.");
                }

                var activitiesDtoList = activityList.Select(_entityMapper.ActivityToActivityDto)                                                                  .ToList();

                return new Response<IEnumerable<ActivityDto>>(activitiesDtoList);
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<ActivityDto>>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }

        public async Task<Response<ActivityDto>> GetActivityAsync(int id)
        {
            var response = new Response<ActivityDto>();
            try
            {
                var activity = await _unitOfWork.ActivitiesRepository.GetByIdAsync(id);
                
                if (activity == null)
                {
                    return new Response<ActivityDto>(null, false, null, "Not Found");
                }

                if (activity.IsDeleted)
                {
                    return new Response<ActivityDto>(null, false, null, "Activity is deleted");
                }

                return new Response<ActivityDto>(_entityMapper.ToActivityDto(activity));
            }
            catch (Exception ex)
            {
                return new Response<ActivityDto>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }

        public async Task<Response<InsertActivityDto>> InsertActivityAsync(InsertActivityDto entity)
        {
            try
            {
                var activity = _entityMapper.ToEntity(entity); //MODIFICAR ACA

                if (await _activityRepository.ExistsByTitle(entity.Title))
                {
                    return new Response<InsertActivityDto>(null, false, null, "An activity already exists with that name.");
                }

                await _unitOfWork.ActivitiesRepository.AddAsync(activity);

                await _unitOfWork.SaveChangesAsync();

                return new Response<InsertActivityDto>(_entityMapper.ToInsertDto(activity));
            }
            catch (Exception ex)
            {
                return new Response<InsertActivityDto>(null, false, new string[] { ex.Message, ex.InnerException.Message}, "Server Error");
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

                return new Response<UpdateActivityDto>(_entityMapper.ToUpdateDto(Oldactivity));
            }
            catch (Exception ex)
            {
                return new Response<UpdateActivityDto>(null, false, new string[] { ex.Message, ex.InnerException.Message }, "Server Error");
            }
        }

        public async Task<Response<string>> DeleteAsync(int id)
        {
            try
            {
                var activity = await _unitOfWork.ActivitiesRepository.GetByIdAsync(id);

                if (activity == null)
                {
                    return new Response<string>(null, false, null, "Activity Not Found.");
                }

                if (activity.IsDeleted)
                {
                    return new Response<string>(null, false, null, "Activity already deleted.");
                }

                bool deleted = await _unitOfWork.ActivitiesRepository.Delete(activity);

                _unitOfWork.SaveChanges();

                return new Response<string>(null, true, null, "Activity Deleted");
            }
            catch (Exception ex)
            {
                return new Response<string>(null, false, new string[] { ex.Message, ex.InnerException.Message}, "Server Error");
            }            
        }
    }
}