using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Roles;
using ESVS.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ViewModel;
using ViewModel.Roles;
using Xunit;

namespace ESVSMainUnitTests
{
    public class RoleControllerTests
    {
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
        public async void GetSingleRoleWithBadResult()
        {
            var mock = new Mock<IRoleQuery>();
            var controller = new RolesController();
            var role = Guid.Empty;
            var result = await controller.GetRoleAsync(role, mock.Object);
            var viewResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, viewResult?.StatusCode);
        }


    }
}
