using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ViewModel;
using ViewModel.FieldValues;
using DataAccess.FieldValue;

namespace ESVS.Controllers
{
    [Route("api/[controller]")]
    public class FieldValuesController : Controller
    {
        [HttpGet("GetListFieldValues")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<FieldValueResponse>))]//было userresponce
        public async Task<IActionResult> GetFieldValuesListAsync(FieldValueFilter fieldvalue, ListOptions options, [FromServices]IFieldValueListQuery query)
        {
            var response = await query.RunAsync(fieldvalue, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetFieldValue/{FieldValueId}", Name = "GetSingleFieldValue")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(FieldValueResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFieldValueAsync(Guid FieldValueId, [FromServices] IFieldValueQuery query)
        {
            FieldValueResponse response = await query.RunAsync(FieldValueId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("CreateFieldValue")]
        [ProducesResponseType(201, Type = typeof(FieldValueResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFieldValue(CreateFieldValueRequest fieldvalue, [FromServices] ICreateFieldValueCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                FieldValueResponse response = await command.ExecuteAsync(fieldvalue);
                return CreatedAtRoute("GetSingleFieldValue", new { FieldValueId = response.Id }, response);

            }
            catch (CannotCreateFieldValueExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut("UpdateFieldValue/{FieldValueId}")]
        [ProducesResponseType(201, Type = typeof(FieldValueResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateFieldValue(Guid FieldValueId, UpdateFieldValueRequest fieldvalue, [FromServices] IUpdateFieldValueCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                FieldValueResponse response = await command.ExecuteAsync(FieldValueId, fieldvalue);
                return CreatedAtRoute("GetSingleFieldValue", new { FieldValueId = response.Id }, response);

            }
            catch (CannotCreateFieldValueExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }
        //[Authorize(Roles = "admin")]
        [HttpDelete("DeleteFieldValue/{FieldValueId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteFieldValueAsync(Guid FieldValueId, [FromServices]IDeleteFieldValueCommand command)
        {
            try
            {
                await command.ExecuteAsync(FieldValueId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}