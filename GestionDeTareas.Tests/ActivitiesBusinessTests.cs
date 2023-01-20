using GestionDeTareas.API.Core.Business;
using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Mapper;
using GestionDeTareas.API.Core.Models.DTOs.Activity;
using GestionDeTareas.API.Entities;
using GestionDeTareas.API.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GestionDeTareas.Tests
{
    public class ActivitiesBusinessTests
    {
        [Fact]
        public async Task GetActivitiesAsync_ReturnsList()
        {
            // Arrange
            var activities = new List<Activity> {
                    new Activity { Id = 1, Title = "Activity 1" },
                    new Activity { Id = 2, Title = "Activity 2" }
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ActivitiesRepository.GetAllAsync(It.IsAny<bool>()))
                          .ReturnsAsync(activities);

            var mockEntityMapper = new Mock<IEntityMapper>();
            mockEntityMapper.Setup(mapper => mapper.ActivityToActivityDto(It.IsAny<Activity>()))
                            .Returns((Activity activity) => new ActivityDto { Title = activity.Title });

            var service = new ActivitiesBusiness(mockUnitOfWork.Object, mockEntityMapper.Object, null);

            // Act
            var result = await service.GetActivitiesAsync(false);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Succeeded);
            Assert.NotEmpty(result.Data);
            Assert.Equal(activities.Count, result.Data.Count());
            Assert.Equal(activities[0].Title, result.Data.ElementAt(0).Title);
            Assert.Equal(activities[1].Title, result.Data.ElementAt(1).Title);
        }

        [Fact]
        public async Task GetActivitiesAsync_EmptyList_ReturnsResponse()
        {
            // Arrange
            var activities = new List<Activity>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ActivitiesRepository.GetAllAsync(It.IsAny<bool>()))
                         .ReturnsAsync(activities);

            var mockEntityMapper = new Mock<IEntityMapper>();

            var service = new ActivitiesBusiness(mockUnitOfWork.Object, mockEntityMapper.Object, null);

            // Act
            var result = await service.GetActivitiesAsync(false);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Succeeded);
            Assert.Null(result.Data);
            Assert.Equal("Table is Empty.", result.Message);
        }

        [Fact]
        public async Task GetActivitiesAsync_Exception_ReturnsResponse_WithErrorList()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.ActivitiesRepository.GetAllAsync(It.IsAny<bool>()))
                         .ThrowsAsync(new Exception("Some exception message"));

            var mockEntityMapper = new Mock<IEntityMapper>();

            var service = new ActivitiesBusiness(mockUnitOfWork.Object, mockEntityMapper.Object, null);

            // Act
            var result = await service.GetActivitiesAsync(false);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Succeeded);
            Assert.Null(result.Data);
            Assert.Equal("Server Error", result.Message);
            Assert.NotEmpty(result.Errors);
            Assert.Equal("Some exception message", result.Errors.First());
        }

        [Fact]
        public async Task GetActivityAsync_Returns_Activity()
        {
            // Arrange
            var activity = new Activity
            {
                Id = 1,
                Title = "Test Activity",
                Description = "test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var activityDto = new ActivityDto
            {
                //Id = 1,
                Title = "Test Activity",
                Description = "test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.ActivitiesRepository.GetByIdAsync(activity.Id)).ReturnsAsync(activity);

            var entityMapperMock = new Mock<IEntityMapper>();
            entityMapperMock
                .Setup(mapper => mapper.ToActivityDto(activity))
                .Returns(activityDto);

            var service = new ActivitiesBusiness(mockUnitOfWork.Object, entityMapperMock.Object, null);

            // Act
            var result = await service.GetActivityAsync(activity.Id);

            // Assert
            Assert.True(result.Succeeded);
            Assert.Equal(activityDto, result.Data);
            Assert.Empty(result.Errors);
            Assert.NotEmpty(result.Message);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public async Task GetActivityAsync_Returns_NotFound()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.ActivitiesRepository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Activity)null);

            var entityMapperMock = new Mock<IEntityMapper>();
            var service = new ActivitiesBusiness(mockUnitOfWork.Object, entityMapperMock.Object, null);

            // Act
            var result = await service.GetActivityAsync(1);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Null(result.Data);
            Assert.Empty(result.Errors);
            Assert.Equal("Not Found", result.Message);
        }

        [Fact]
        public async Task GetActivityAsync_Returns_ActivityIsDeleted()
        {
            // Arrange
            var activity = new Activity
            {
                Id = 1,
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                IsDeleted = true,
                CategoryId = 1
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.ActivitiesRepository.GetByIdAsync(activity.Id)).ReturnsAsync(activity);

            var entityMapperMock = new Mock<IEntityMapper>();
            var service = new ActivitiesBusiness(mockUnitOfWork.Object, entityMapperMock.Object, null);

            // Act
            var result = await service.GetActivityAsync(activity.Id);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Null(result.Data);
            Assert.Empty(result.Errors);
            Assert.Equal("Activity is deleted", result.Message);
        }

        [Fact]
        public async Task GetActivityAsync_Exception_ReturnsResponseWithEx()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.ActivitiesRepository.GetByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Test Exception"));

            var entityMapperMock = new Mock<IEntityMapper>();
            var service = new ActivitiesBusiness(mockUnitOfWork.Object, entityMapperMock.Object, null);

            // Act
            var result = await service.GetActivityAsync(1);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Null(result.Data);
            Assert.Contains("Test Exception", result.Errors);
            Assert.Equal("Server Error", result.Message);
        }

        [Fact]
        public async Task InsertActivityAsync_Returns_ResponseInsertedActivity()
        {
            // Arrange
            var activityDto = new InsertActivityDto
            {
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var activity = new Activity
            {
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.ActivitiesRepository.AddAsync(activity)).ReturnsAsync(activity);

            var entityMapperMock = new Mock<IEntityMapper>();
            entityMapperMock.Setup(x => x.ToEntity(activityDto)).Returns(activity);

            entityMapperMock.Setup(x => x.ToInsertDto(activity)).Returns(activityDto);

            var mockActivityRepository = new Mock<IActivityRepository>();
            var service = new ActivitiesBusiness(mockUnitOfWork.Object, entityMapperMock.Object, mockActivityRepository.Object);

            // Act
            var result = await service.InsertActivityAsync(activityDto);

            // Assert
            mockUnitOfWork.Verify(x => x.ActivitiesRepository.AddAsync(activity), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.True(result.Succeeded);
            Assert.Empty(result.Errors);
            Assert.Equal("Success", result.Message);
            Assert.IsType<InsertActivityDto>(result.Data);
            Assert.Equal(activityDto.Title, result.Data.Title);
            Assert.Equal(activityDto.Description, result.Data.Description);
            Assert.Equal(activityDto.IsCompleted, result.Data.IsCompleted);
            Assert.Equal(activityDto.CategoryId, result.Data.CategoryId);
        }

        [Fact]
        public async Task InsertActivityAsync_NameAlreadyExists_ResponseWithMessageError()
        {
            // Arrange
            var activityDto = new InsertActivityDto
            {
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var activity = new Activity
            {
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockEntityMapper = new Mock<IEntityMapper>();

            var mockActivityRepository = new Mock<IActivityRepository>();
            mockActivityRepository.Setup(x => x.ExistsByTitle(activityDto.Title)).ReturnsAsync(true);

            var service = new ActivitiesBusiness(mockUnitOfWork.Object, mockEntityMapper.Object, mockActivityRepository.Object);

            // Act
            var result = await service.InsertActivityAsync(activityDto);

            // Assert
            mockUnitOfWork.Verify(x => x.ActivitiesRepository.AddAsync(activity), Times.Never);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Never);
            mockActivityRepository.Verify(x => x.ExistsByTitle(activityDto.Title), Times.Once);
            Assert.False(result.Succeeded);
            Assert.Empty(result.Errors);
            Assert.Equal("An activity already exists with that name.", result.Message);
        }

        [Fact]
        public async Task InsertActivityAsync_Exception_ResponseWithExErrors()
        {
            // Arrange
            var activityDto = new InsertActivityDto
            {
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var activity = new Activity
            {
                Title = "Test Activity",
                Description = "This is a test activity",
                IsCompleted = false,
                CategoryId = 1
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.ActivitiesRepository.AddAsync(activity)).ThrowsAsync(new Exception("Some exception message"));

            var entityMapperMock = new Mock<IEntityMapper>();
            entityMapperMock.Setup(x => x.ToEntity(activityDto)).Returns(activity);

            var mockActivityRepository = new Mock<IActivityRepository>();
            var service = new ActivitiesBusiness(mockUnitOfWork.Object, entityMapperMock.Object, mockActivityRepository.Object);

            // Act
            var result = await service.InsertActivityAsync(activityDto);

            // Assert
            mockUnitOfWork.Verify(x => x.ActivitiesRepository.AddAsync(activity), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Never);
            Assert.False(result.Succeeded);
            Assert.Equal("Server Error", result.Message);
            Assert.NotEmpty(result.Errors);
            Assert.Equal("Some exception message", result.Errors.First());
        }


    }
}

