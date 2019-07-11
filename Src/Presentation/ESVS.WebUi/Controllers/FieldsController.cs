using System;
using System.Threading.Tasks;
using ESVS.Application.Fields.Commands.CreateField;
using ESVS.Application.Fields.Commands.DeleteField;
using ESVS.Application.Fields.Commands.UpdateField;
using ESVS.Application.Fields.Queries;
using ESVS.Application.Fields.Queries.GetField;
using ESVS.Application.Fields.Queries.GetListFields;
using ESVS.Application.Fields;
using ESVS.Application.Fields.Commands.AddFieldValue;
using ESVS.Application.Infrastructure.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESVS.WebUi.Controllers
{
    public class FieldsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListResponse<FieldViewModel>>> GetAll([FromQuery]GetListFieldsQuery query) =>

           Ok(await Mediator.Send(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<FieldViewModel>> Get(Guid id) =>

            Ok(await Mediator.Send(new GetFieldQuery { Id = id }));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFieldCommand command)
        {
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateFieldCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddFieldValue([FromBody] AddFieldValueCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteFieldCommand { Id = id });
            return NoContent();
        }
    }
}
