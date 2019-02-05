using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Roles;
using ESVS.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ViewModel;
using ViewModel.Roles;
using ViewModel.Users;
using Xunit;

namespace ESVSMainUnitTests
{
    public class RoleControllerTests
    {
        private static readonly RolesController Controller =
            new RolesController();

        [Fact]
        public async void GetListRolesWithOkResult()
        {
            var roleFilter = new RoleFilter();
            var options = new ListOptions();
            var mock = new Mock<IRolesListQuery>();
            mock.Setup(u => u.RunAsync(roleFilter, options)).ReturnsAsync(new ListResponse<RoleResponse>());

            var result = await Controller.GetRoleListAsync(roleFilter, options, mock.Object);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ListResponse<RoleResponse>>(viewResult.Value);
        }

        [Fact]
        public async void GetSingleRoleWithBadResult()
        {
            var mock = new Mock<IRoleQuery>();
            var roleId = Guid.NewGuid();
            mock.Setup(user => user.RunAsync(roleId)).ReturnsAsync((RoleResponse)null);

            var result = await Controller.GetRoleAsync(roleId, mock.Object);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void CreateRoleWithOkModel()
        {
            var mock = new Mock<ICreateRoleCommand>();
            var user = new CreateRoleRequest();

            mock.Setup(u => u.ExecuteAsync(user)).ReturnsAsync(
                new RoleResponse()
                {
                    Id = Guid.NewGuid()
                }
            );

            var result = await Controller.CreateRole(user, mock.Object);

            var viewResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.IsType<RoleResponse>(viewResult.Value);

        }

        [Fact]
        public async void CreateRoleWithBadModel()
        {
            var mock = new Mock<ICreateRoleCommand>();
            var role = new CreateRoleRequest();
            Controller.ModelState.AddModelError("Email", "Required");

            var result = await Controller.CreateRole(role, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void CreateRoleBadModelWithExceptionFromCommand()
        {
            var mock = new Mock<ICreateRoleCommand>();
            var roleRequest = new CreateRoleRequest();
            mock.Setup(u => u.ExecuteAsync(roleRequest))
                .ThrowsAsync(new CannotCreateRoleException(new List<IdentityError>()));

            var result = await Controller.CreateRole(roleRequest, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void UpdateRoleWithOkModel()
        {
            var mock = new Mock<IUpdateRoleCommand>();
            var role = new UpdateRoleRequest();

            mock.Setup(u => u.ExecuteAsync(role)).ReturnsAsync(
                new RoleResponse()
                {
                    Id = Guid.NewGuid()
                }
            );

            var result = await Controller.UpdateRole(role, mock.Object);

            var viewResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.IsType<RoleResponse>(viewResult.Value);

        }

        [Fact]
        public async void UpdateRoleWithBadModel()
        {
            var mock = new Mock<IUpdateRoleCommand>();
            var role = new UpdateRoleRequest();
            Controller.ModelState.AddModelError("Email", "Required");

            var result = await Controller.UpdateRole(role, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void UpdateRoleBadModelWithExceptionFromCommand()
        {
            var mock = new Mock<IUpdateRoleCommand>();
            var roleRequest = new UpdateRoleRequest();
            mock.Setup(u => u.ExecuteAsync(roleRequest))
                .ThrowsAsync(new CannotCreateRoleException(new List<IdentityError>()));

            var result = await Controller.UpdateRole(roleRequest, mock.Object);

            Assert.IsType<BadRequestObjectResult>(result);

        }

        [Fact]
        public async void DeleteAction()
        {
            var roleId = Guid.NewGuid();
            var mock = new Mock<IDeleteRoleCommand>();
            var result = await Controller.DeleteRoleAsync(roleId, mock.Object);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void DeleteActWithException()
        {
            var roleId = Guid.NewGuid();
            var mock = new Mock<IDeleteRoleCommand>();
            mock.Setup(u => u.ExecuteAsync(roleId)).ThrowsAsync(new Exception());
            var result = await Controller.DeleteRoleAsync(roleId, mock.Object);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void AddRoleToUserWithOkModel()
        {
            var mock = new Mock<IAddRoleToUserCommand>();
            var roleId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            mock.Setup(u => u.ExecuteAsync(roleId, userId)).ReturnsAsync(
                new RoleResponse()
                {
                    Id = roleId
                }
            );

            var result = await Controller.AddRoleToUserAsync(roleId, userId, mock.Object);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<RoleResponse>(viewResult.Value);

        }
    }
}
