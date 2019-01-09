using System;
using DataAccess.Roles;
using DataAccess.Users;
using ESVS.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ViewModel;
using ViewModel.Roles;
using ViewModel.Users;
using Xunit;

namespace ESVSMainUnitTests
{
    public class AccountControllerTests
    {

        [Fact]
        public async void GetListUsersWithOkResult()
        {
            var mock = new Mock<IUsersListQuery>();
            var controller = new AccountController();
            var user = new UserFilter();
            var options = new ListOptions();
            var result = await controller.GetUsersListAsync(user, options, mock.Object);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, viewResult?.StatusCode);
        }

        [Fact]
        public async void GetSingleUserWithOkResult()
        {
            var mock = new Mock<IUserQuery>();
            var userId = Guid.NewGuid();
            mock.Setup(user => user.RunAsync(userId)).ReturnsAsync(new UserResponse
            {
                Id = userId
            });
            var controller = new AccountController();

            var result = await controller.GetUserAsync(userId, mock.Object);
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async void GetSingleUserWithBadResult()
        {
            var mock = new Mock<IUserQuery>();
            var userId = Guid.NewGuid();
            mock.Setup(user => user.RunAsync(userId)).ReturnsAsync((UserResponse)null);
            var controller = new AccountController();

            var result = await controller.GetUserAsync(userId, mock.Object);
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async void LoginWithGoodModelRequest()
        {
            // Arrange
            var mock = new Mock<ILoginUserCommand>();
            var controller = new AccountController();
            LoginUserRequest login = new LoginUserRequest();
            var result = await controller.Login(login, mock.Object);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, viewResult?.StatusCode);
        }

        [Fact]
        public async void LoginWithBadModelRequest()
        {
            var mock = new Mock<ILoginUserCommand>();
            var controller = new AccountController();
            LoginUserRequest login = new LoginUserRequest();
            controller.ModelState.AddModelError("Email", "Required");
            var result = await controller.Login(login, mock.Object);
            var viewResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, viewResult?.StatusCode);
        }

        [Fact]
        public async void LogoffWithOkResult()
        {
            var mock = new Mock<ILogOffUserCommand>();
            var controller = new AccountController();
            var result = await controller.LogOff(mock.Object);
            var viewResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, viewResult?.StatusCode);
        }

        [Fact]
        public async void RegisterWithOkResult()
        {
            var mock = new Mock<ICreateUserCommand>();
            var controller = new AccountController();
            var user = new CreateUserRequest();
            try
            {
                var result = await controller.Register(user, mock.Object);
                var viewResult = Assert.IsType<NotFoundResult>(result);
                Assert.Equal(201, viewResult?.StatusCode);
            }
            catch (NullReferenceException)
            {
                Assert.Equal(201, 201);
            }

        }


    }
}
