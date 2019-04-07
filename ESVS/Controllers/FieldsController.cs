using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Field;
using Microsoft.AspNetCore.Authorization;
using ViewModel;
using ViewModel.Fields;

namespace ESVS.Controllers
{
    [Route("api/[controller]")]
    public class FieldsController : Controller
    {
        [HttpGet("GetListFields")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<FieldResponse>))]//было userresponce
        public async Task<IActionResult> GetFieldsListAsync(FieldFilter field, ListOptions options, [FromServices]IFieldListQuery query)
        {
            var response = await query.RunAsync(field, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetField/{FieldId}", Name = "GetSingleField")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(FieldResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFieldAsync(Guid FieldId, [FromServices] IFieldQuery query)
        {
            FieldResponse response = await query.RunAsync(FieldId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("CreateField")]
        [ProducesResponseType(201, Type = typeof(FieldResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateField(CreateFieldRequest field, [FromServices] ICreateFieldCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                FieldResponse response = await command.ExecuteAsync(field);
                return CreatedAtRoute("GetSingleField", new { FieldId = response.Id }, response);

            }
            catch (CannotCreateFieldExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut("UpdateField/{FieldId}")]
        [ProducesResponseType(201, Type = typeof(FieldResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateField(Guid FieldId, UpdateFieldRequest field, [FromServices] IUpdateFieldCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                FieldResponse response = await command.ExecuteAsync(FieldId, field);
                return CreatedAtRoute("GetSingleField", new { FieldId = response.Id }, response);

            }
            catch (CannotCreateFieldExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }
        //[Authorize(Roles = "admin")]
        [HttpDelete("DeleteField/{FieldId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteFieldAsync(Guid FieldId, [FromServices]IDeleteFieldCommand command)
        {
            try
            {
                await command.ExecuteAsync(FieldId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}