using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Roles;
using DataAccess.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using ViewModel.Roles;
using ViewModel.Users;

namespace ESVS.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        [HttpGet("GetListRoles")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<UserResponse>))]
        public async Task<IActionResult> GetRoleListAsync(RoleFilter role, ListOptions options, [FromServices]IRolesListQuery query)
        {
            var response = await query.RunAsync(role, options);     // запрос к базе 
            return Ok(response);
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

        [HttpPut("UpdateRole/{roleId}")]
        [ProducesResponseType(201, Type = typeof(UserResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateRole(Guid roleId,UpdateRoleRequest role, [FromServices] IUpdateRoleCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                RoleResponse response = await command.ExecuteAsync(roleId,role);
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



        [HttpPut("{roleId}/users/{userId}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddRoleToUserAsync(Guid roleId, Guid userId, [FromServices]IAddRoleToUserCommand command)
        {
            RoleResponse response = await command.ExecuteAsync(roleId, userId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }


        [HttpDelete("{roleId}/users/{userId}")]
        [ProducesResponseType(204)]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveRoleFromUserAsync(Guid roleId, Guid userId, [FromServices] IRemoveRoleFromUserCommand command)
        {
            await command.ExecuteAsync(roleId, userId);
            return NoContent();
        }
    

}
}