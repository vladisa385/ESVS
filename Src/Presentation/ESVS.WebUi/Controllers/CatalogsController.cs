using System;
using System.Threading.Tasks;
using ESVS.Application.Catalogs.Commands.CreateCatalog;
using ESVS.Application.Catalogs.Commands.DeleteCatalog;
using ESVS.Application.Catalogs.Commands.UpdateCatalog;
using ESVS.Application.Catalogs.Queries;
using ESVS.Application.Catalogs.Queries.GetCatalog;
using ESVS.Application.Catalogs.Queries.GetListCatalogs;
using ESVS.Application.Infrastructure.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESVS.WebUi.Controllers
{
    public class CatalogsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListResponse<CatalogViewModel>>> GetAll([FromQuery]GetListCatalogsQuery query) => 
           
            Ok(await Mediator.Send(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogViewModel>> Get(Guid id) => 
            
            Ok(await Mediator.Send(new GetCatalogQuery { Id = id }));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCatalogCommand command)
        {
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateCatalogCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteCatalogCommand { Id = id });
            return NoContent();
        }
    }
}