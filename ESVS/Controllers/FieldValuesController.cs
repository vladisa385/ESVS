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
        [ProducesResponseType(200, Type = typeof(ListResponse<FieldValuesResponse>))]//было userresponce
        public async Task<IActionResult> GetFieldValuesListAsync(FieldValuesFilter fieldvalues, ListOptions options, [FromServices]IFieldValuesListQuery query)
        {
            var response = await query.RunAsync(fieldvalues, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetFieldValue/{FieldValueId}", Name = "GetSingleFieldValues")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(FieldValuesResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFieldValuesAsync(Guid fieldValueId, [FromServices] IFieldValuesQuery query)
        {
            FieldValuesResponse response = await query.RunAsync(fieldValueId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("CreateFieldValue")]
        [ProducesResponseType(201, Type = typeof(FieldValuesResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFieldValue([FromBody]CreateFieldValuesRequest fieldvalue, [FromServices] ICreateFieldValuesCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                FieldValuesResponse response = await command.ExecuteAsync(fieldvalue);
                return CreatedAtRoute("GetSingleFieldValues", new { FieldValueId = response.Id }, response);

            }
            catch (CannotCreateFieldValuesException exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut("UpdateFieldValue/{FieldValueId}")]
        [ProducesResponseType(201, Type = typeof(FieldValuesResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateFieldValue(Guid fieldValueId, [FromBody] UpdateFieldValuesRequest fieldvalues, [FromServices] IUpdateFieldValuesCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                FieldValuesResponse response = await command.ExecuteAsync(fieldValueId, fieldvalues);
                return CreatedAtRoute("GetSingleFieldValues", new { FieldValueId = response.Id }, response);

            }
            catch (CannotCreateFieldValuesException exception)
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
        public async Task<IActionResult> DeleteFieldValueAsync(Guid fieldValueId, [FromServices]IDeleteFieldValuesCommand command)
        {
            try
            {
                await command.ExecuteAsync(fieldValueId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}