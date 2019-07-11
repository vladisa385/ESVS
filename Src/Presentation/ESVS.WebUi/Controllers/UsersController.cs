using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESVS.Application.Catalogs.Queries;
using ESVS.Application.Catalogs.Queries.GetCatalog;
using ESVS.Application.Infrastructure.Query;
using ESVS.Application.Users.Commands.Login;
using ESVS.Application.Users.Commands.Logoff;
using ESVS.Application.Users.Commands.RegisterUser;
using ESVS.Application.Users.Queries;
using ESVS.Application.Users.Queries.GetAllUsers;
using Microsoft.AspNetCore.Mvc;

namespace ESVS.WebUi.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListResponse<UserViewModel>>> GetAll([FromQuery]GetListUsersQuery query) =>

           Ok(await Mediator.Send(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(Guid id) =>

            Ok(await Mediator.Send(new GetListUsersQuery() { Id = id }));

        [HttpPost]
        public async Task<ActionResult<Guid>> Register([FromBody] RegisterUserCommand command)
        {
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Login([FromBody] LoginCommand command)
        {
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> LogOff([FromBody] LogOffCommand command)
        {
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

    }
}