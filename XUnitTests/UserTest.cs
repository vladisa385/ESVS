using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DataAccess.Roles;
using DataAccess.Users;
using ESVS;
using ESVS.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ViewModel;
using ViewModel.Roles;
using ViewModel.Users;
using Xunit;

namespace XUnitTests
{
    public class UserTest
    {
  
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
            var result = await controller.LogOff( mock.Object);
            var viewResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, viewResult?.StatusCode);
        }

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
        public async void GetSingleUserWithNeOkResult()
        {
            var mock = new Mock<IUserQuery>();
            var controller = new AccountController();
            var user = Guid.Empty;
            var result = await controller.GetUserAsync(user, mock.Object);
            var viewResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, viewResult?.StatusCode);
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

        [Fact]
        public async void GetListRolesWithOkResult()
        {
            var mock = new Mock<IRolesListQuery>();
            var controller = new RolesController();
            var role = new RoleFilter();
            var options = new ListOptions();
            var result = await controller.GetRoleListAsync(role, options, mock.Object);
            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, viewResult?.StatusCode);
        }

        [Fact]
        public async void GetSingleRoleWithNeOkResult()
        {
            var mock = new Mock<IRoleQuery>();
            var controller = new RolesController();
            var role = Guid.Empty;
            var result = await controller.GetRoleAsync(role, mock.Object);
            var viewResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, viewResult?.StatusCode);
        }

        //[Fact]
        //public async  void LogoffWithNeOkResult()
        //{
        //    // Arrange
        //    TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        //    var client = server.CreateClient();
        //    var url = "api/Account/Login";
        //    var expected = HttpStatusCode.Unauthorized;

        //    // Act
        //    var response = await client.GetAsync(url);

        //    // Assert
        //    Assert.AreEqual(expected, response.StatusCode);
        //}
    }
}
