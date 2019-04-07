using System;
using System.Threading.Tasks;
using DataAccess.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ViewModel;
using ViewModel.Catalogs;

namespace ESVS.Controllers
{
    [Route("api/[controller]")]
    public class CatalogsController : Controller
    {
        [HttpGet("GetListCatalogs")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<CatalogResponse>))]//было userresponce
        public async Task<IActionResult> GetCatalogsListAsync(CatalogFilter catalog, ListOptions options, [FromServices]ICatalogListQuery query)
        {
            var response = await query.RunAsync(catalog, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetCatalog/{catalogId}", Name = "GetSingleCatalog")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(CatalogResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCatalogAsync(Guid catalogId, [FromServices] ICatalogQuery query)
        {
            CatalogResponse response = await query.RunAsync(catalogId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("CreateCatalogs")]
        [ProducesResponseType(201, Type = typeof(CatalogResponse))]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<IActionResult> CreateCatalog(CreateCatalogRequest catalog, [FromServices] ICreateCatalogCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CatalogResponse response = await command.ExecuteAsync(catalog);
                return CreatedAtRoute("GetSingleCatalog", new { catalogId = response.Id }, response);

            }
            catch (CannotCreateCatalogException exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut("UpdateCatalogs/{catalogId}")]
        [ProducesResponseType(201, Type = typeof(CatalogResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateCatalogs(Guid catalogId, UpdateCatalogRequest catalog, [FromServices] IUpdateCatalogCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CatalogResponse response = await command.ExecuteAsync(catalogId, catalog);
                return CreatedAtRoute("GetSingleCatalogs", new { catalogId = response.Id }, response);

            }
            catch (CannotCreateCatalogException exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }
        [Authorize]
        [HttpDelete("DeleteCatalog/{catalogId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCatalogAsync(Guid catalogId, [FromServices]IDeleteCatalogCommand command)
        {
            try
            {
                await command.ExecuteAsync(catalogId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}