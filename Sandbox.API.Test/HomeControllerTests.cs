using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sandbox.API.Controllers;
using Sandbox.Business.Interfaces;
using Sandbox.Business.Models;
using Xunit;

namespace Sandbox.API.UnitTest
{

    public class HomeControllerTests
    {
        [Fact]
        public void Index_WhenCalled_ShouldReturn_Status200OK()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var expected = controller.Index();

            // Assert
            var result = Assert.IsType<OkResult>(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ListAsync_WhenCalled_ShouldReturn_AllUsers()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo
                    .ListAsync())
                    .ReturnsAsync(MockData);
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.ListAsync();

            // Assert
            var actionResult = Assert.IsType<Task<IEnumerable<User>>>(result);
            Assert.Equal(25, actionResult.Result.Count());
        }

        [Fact]
        public void GetUserById_WhenCalled_ShouldReturn_SingleUser()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => repo
                    .GetByIdAsync(Guid.Parse("aa609ac5-974d-487f-9df1-4ae37fbad29c")))
                .Returns(Task.FromResult(MockDataSingleUser()));

            var controller = new HomeController(mockRepo.Object);

            // Act
            var expected = controller.GetUserById(Guid.Parse("aa609ac5-974d-487f-9df1-4ae37fbad29c"));

            // Assert
            var result = Assert.IsType<Task<User>>(expected);
            Assert.Equal(expected, result);
        }

        private static User MockDataSingleUser()
        {
            var user = new User
            {
                Id = Guid.Parse("aa609ac5-974d-487f-9df1-4ae37fbad29c"),
                Name = "Rodrigo",
                Email = "rodrigo@gmail.com"
            };

            return user;
        }

        private static List<User> MockData()
        {
            var userList = new List<User>();

            for (var i = 1; i <= 25; i++)
            {
                var user = new User
                {
                    Name = $"User {i}",
                    Email = $"user{i}@gmail.com"
                };

                userList.Add(user);
            }

            return userList;
        }

    }
}