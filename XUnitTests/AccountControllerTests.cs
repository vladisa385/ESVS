using System;
using System.Collections.Generic;
using DataAccess.Users;
using ESVS.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ViewModel;
using ViewModel.Users;
using Xunit;

namespace ESVSMainUnitTests
{
    public class AccountControllerTests : IDisposable
    {
        private static readonly AccountController Controller =
            new AccountController();

        [Fact]
        public async void GetListUsersWithOkResult()
        {
            var userFilter = new UserFilter();
            var options = new ListOptions();
            var mock = new Mock<IUsersListQuery>();
            mock.Setup(u => u.RunAsync(userFilter, options)).ReturnsAsync(new ListResponse<UserResponse>());

            var result = await Controller.GetUsersListAsync(userFilter, options, mock.Object);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ListResponse<UserResponse>>(viewResult.Value);
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

            var result = await Controller.GetUserAsync(userId, mock.Object);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(userId, ((UserResponse)viewResult.Value).Id);

        }

        [Fact]
        public async void GetSingleUserWithBadResult()
        {
            var mock = new Mock<IUserQuery>();
            var userId = Guid.NewGuid();
            mock.Setup(user => user.RunAsync(userId)).ReturnsAsync((UserResponse)null);

            var result = await Controller.GetUserAsync(userId, mock.Object);

            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public async void RegisterWithOkModel()
        {
            var mock = new Mock<ICreateUserCommand>();
            var user = new CreateUserRequest();

            mock.Setup(u => u.ExecuteAsync(user)).ReturnsAsync(
                new UserResponse()
                {
                    Id = Guid.NewGuid()
                }
                );

            var result = await Controller.Register(user, mock.Object);

            var viewResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.IsType<UserResponse>(viewResult.Value);

        }


        [Fact]
        public async void RegisterWithBadModel()
        {
            var mock = new Mock<ICreateUserCommand>();
            var user = new CreateUserRequest();
            Controller.ModelState.AddModelError("Email", "Required");

            var result = await Controller.Register(user, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async void RegisterBadModelWithExceptionFromCommand()
        {
            var mock = new Mock<ICreateUserCommand>();
            var userRequest = new CreateUserRequest();
            mock.Setup(u => u.ExecuteAsync(userRequest))
                .ThrowsAsync(new UserCredentialsException(new List<IdentityError>()));

            var result = await Controller.Register(userRequest, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);

        }


        [Fact]
        public async void LoginWithOkModel()
        {
            var mock = new Mock<ILoginUserCommand>();
            var loginUser = new LoginUserRequest();

            mock.Setup(u => u.ExecuteAsync(loginUser)).ReturnsAsync(
                new UserResponse()
                {
                    Id = Guid.NewGuid()
                }
                );

            var result = await Controller.Login(loginUser, mock.Object);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<UserResponse>(viewResult.Value);

        }


        [Fact]
        public async void LoginWithBadModel()
        {
            var mock = new Mock<ILoginUserCommand>();
            var loginUser = new LoginUserRequest();
            Controller.ModelState.AddModelError("Email", "Required");

            var result = await Controller.Login(loginUser, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async void LoginBadModelWithExceptionFromCommand()
        {
            var mock = new Mock<ILoginUserCommand>();
            var loginUser = new LoginUserRequest();
            mock.Setup(u => u.ExecuteAsync(loginUser))
                .ThrowsAsync(new UserCredentialsException(new List<IdentityError>()));

            var result = await Controller.Login(loginUser, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);

        }


        [Fact]
        public async void UpdateUserWithOkModel()
        {
            var mock = new Mock<IUpdateUserCommand>();
            var user = new UpdateUserRequest();

            mock.Setup(u => u.ExecuteAsync(user)).ReturnsAsync(
                new UserResponse()
                {
                    Id = Guid.NewGuid()
                }
                );

            var result = await Controller.UpdateUser(user, mock.Object);

            var viewResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.IsType<UserResponse>(viewResult.Value);

        }


        [Fact]
        public async void UpdateUserWithBadModel()
        {
            var mock = new Mock<IUpdateUserCommand>();
            var user = new UpdateUserRequest();
            Controller.ModelState.AddModelError("Email", "Required");

            var result = await Controller.UpdateUser(user, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async void UpdateUserBadModelWithExceptionFromCommand()
        {
            var mock = new Mock<IUpdateUserCommand>();
            var userRequest = new UpdateUserRequest();
            mock.Setup(u => u.ExecuteAsync(userRequest))
                .ThrowsAsync(new UserCredentialsException(new List<IdentityError>()));

            var result = await Controller.UpdateUser(userRequest, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);

        }


        [Fact]
        public async void DeleteAction()
        {
            var userId = Guid.NewGuid();
            var mock = new Mock<IDeleteUserCommand>();
            var result = await Controller.DeleteUserAsync(userId, mock.Object);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void DeleteActWithException()
        {
            var userId = Guid.NewGuid();
            var mock = new Mock<IDeleteUserCommand>();
            mock.Setup(u => u.ExecuteAsync(userId)).ThrowsAsync(new Exception());
            var result = await Controller.DeleteUserAsync(userId, mock.Object);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void LogoffAction()
        {
            var mock = new Mock<ILogOffUserCommand>();
            var result = await Controller.LogOff(mock.Object);

            Assert.IsType<OkResult>(result);
        }


        public void Dispose()
        {
            Controller.ModelState.Clear();
        }
    }
}
