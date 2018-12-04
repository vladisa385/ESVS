using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Roles;
using DataAccess.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ViewModel;
using ViewModel.Roles;
using ViewModel.Users;

namespace ESVS.Controllers
{
    [Route("api/[controller]")]
    public class CatalogOfCatalogsController : Controller
    {
        [HttpGet("GetListCatalogOfCatalogs")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<CatalogOfCatalogsResponse>))]//было userresponce
        public async Task<IActionResult> GetCatalogOfCatalogsListAsync(CatalogOfCatalogsFilter catalogofcatalogs, ListOptions options, [FromServices]ICatalogOfCatalogsListQuery query)
        {
            var response = await query.RunAsync(catalogofcatalogs, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetCatalogOfCatalogs/{catalogofcatalogsId}", Name = "GetSingleCatalogOfCatalogs")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(CatalogOfCatalogsResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCatalogOfCatalogsAsync(Guid catalogofcatalogsId, [FromServices] ICatalogOfCatalogsQuery query)
        {
            CatalogOfCatalogsResponse response = await query.RunAsync(catalogofcatalogsId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("CreateCatalogOfCatalogs")]
        [ProducesResponseType(201, Type = typeof(CatalogOfCatalogsResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCatalogOfCatalogs(CreateCatalogOfCatalogsRequest catalogofcatalogs, [FromServices] ICreateCatalogOfCatalogsCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CatalogOfCatalogsResponse response = await command.ExecuteAsync(catalogofcatalogs);
                return CreatedAtRoute("GetSingleCatalogOfCatalogs", new { catalogofcatalogsId = response.Id }, response);

            }
            catch (CannotCreateCatalogOfCatalogsExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut("UpdateCatalogOfCatalogs/{catalogofcatalogsId}")]
        [ProducesResponseType(201, Type = typeof(CatalogOfCatalogsResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateCatalogOfCatalogs(Guid catalogofcatalogsId, UpdateCatalogOfCatalogsRequest catalogofcatalogs, [FromServices] IUpdateCatalogOfCatalogsCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CatalogOfCatalogsResponse response = await command.ExecuteAsync(catalogofcatalogsId, catalogofcatalogs);
                return CreatedAtRoute("GetSingleCatalogOfCatalogs", new { catalogofcatalogsId = response.Id }, response);

            }
            catch (CannotCreateCatalogOfCatalogsExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }
        //[Authorize(Roles = "admin")]
        [HttpDelete("DeleteCatalogOfCatalogs/{catalogofcatalogsId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCatalogOfCatalogsAsync(Guid catalogofcatalogsId, [FromServices]IDeleteCatalogOfCatalogsCommand command)
        {
            try
            {
                await command.ExecuteAsync(catalogofcatalogsId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}