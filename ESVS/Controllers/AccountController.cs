using System;
using System.Threading.Tasks;
using DataAccess.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using ViewModel.Users;

namespace ESVS.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        //200 - OK
        //400 - 
        // CreateRole like a Register +
        // GetListRoles like a GetList +
        // GetRoles/{roleId} like a Get/{userId} +
        // DeleteRole/{roleId} like a Delete/{userId} +
        // UpdateRole like a UpdateUser +
        // AddRoleToUser/{roleId} & /{userId}
        // DeleteRoleToUser/{roleId} & /{userId}

        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<UserResponse>))]
        public async Task<IActionResult> GetUsersListAsync(UserFilter user, ListOptions options, [FromServices]IUsersListQuery query)
        {
            var response = await query.RunAsync(user, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetListRoles")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<UserResponse>))]
        public async Task<IActionResult> GetRoleListAsync(RoleFilter role, ListOptions options, [FromServices]IRolesListQuery query)
        {
            var response = await query.RunAsync(role, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("Get/{userId}", Name = "GetSingleUser")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserAsync(Guid userId, [FromServices] IUserQuery query)
        {
            UserResponse response = await query.RunAsync(userId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpGet("GetRole/{roleId}", Name = "GetSingleRole")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(RoleResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRoleAsync(Guid roleId, [FromServices] IRoleQuery query)
        {
            RoleResponse response = await query.RunAsync(roleId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("Register")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register(CreateUserRequest user, [FromServices] ICreateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);

            }
            catch (CannotCreateUserExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }


        [HttpPost("UpdateUser")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest user, [FromServices] IUpdateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);

            }
            catch (CannotCreateUserExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }

        [HttpPost("UpdateRole")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest role, [FromServices] IUpdateRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(role);
                return CreatedAtRoute("GetSingleRole", new { roleId = response.Id }, response);

            }
            catch (CannotCreateRoleExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }

        [HttpPost("ChangeUserPassword")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordUserRequest user, [FromServices] IChangeUserPasswordCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return CreatedAtRoute("GetSingleUser", new { userId = response.Id }, response);

            }
            catch (CannotChangePasswordExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }

        [HttpPost("Login")]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login(LoginUserRequest user, [FromServices] ILoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                return Ok(response);
            }
            catch (IncorrectPasswordOrEmailExeption exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPost("CreateRole")]
        [ProducesResponseType(201, Type = typeof(RoleResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRole(CreateRoleRequest role, [FromServices] ICreateRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                RoleResponse response = await command.ExecuteAsync(role);
                return CreatedAtRoute("GetSingleRole", new { roleId = response.Id }, response);

            }
            catch (CannotCreateRoleExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("LogOff")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> LogOff([FromServices] ILogOffUserCommand command)
        {
            await command.ExecuteAsync();
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteUserAsync(Guid userId, [FromServices]IDeleteUserCommand command)
        {
            try
            {
                await command.ExecuteAsync(userId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteRole/{roleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteRoleAsync(Guid roleId, [FromServices]IDeleteRoleCommand command)
        {
            try
            {
                await command.ExecuteAsync(roleId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}