using System;
using System.Linq;
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

        [HttpGet("GetList")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<UserResponse>))]
        public async Task<IActionResult> GetUsersListAsync(UserFilter user, ListOptions options, [FromServices]IUsersListQuery query)
        {
            var response = await query.RunAsync(user, options);     // запрос к базе 
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
                var result = CreatedAtRoute(
                    "GetSingleUser",
                    new { userId = response?.Id },
                    response);
                return result;
            }
            catch (UserCredentialsException exception)
            {
                return BadRequest(exception.Errors);
            }
        }


        [HttpPut("UpdateUser")]
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
                var result = CreatedAtRoute(
                    "GetSingleUser",
                    new { userId = response.Id },
                    response);
                return result;
            }
            catch (UserCredentialsException exception)
            {
                return BadRequest(exception);
            }

        }


        [HttpPut("ChangeUserPassword")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> ChangeUserPassword(ChangeUserPasswordRequest user, [FromServices] IChangeUserPasswordCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                UserResponse response = await command.ExecuteAsync(user);
                var result = CreatedAtRoute(
                    "GetSingleUser",
                    new { userId = response.Id },
                    response);
                return result;
            }
            catch (UserCredentialsException)
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut("Login")]
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
            catch (UserCredentialsException exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPut("LogOff")]
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
    }
}