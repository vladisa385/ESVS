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
    public class CatalogsController : Controller
    {
        [HttpGet("GetListCatalogs")]
        [Authorize]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(ListResponse<CatalogsResponse>))]//было userresponce
        public async Task<IActionResult> GetCatalogsListAsync(CatalogsFilter catalogofcatalogs, ListOptions options, [FromServices]ICatalogsListQuery query)
        {
            var response = await query.RunAsync(catalogofcatalogs, options);     // запрос к базе 
            return Ok(response);
        }

        [HttpGet("GetCatalogs/{catalogofcatalogsId}", Name = "GetSingleCatalogs")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(CatalogsResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCatalogsAsync(Guid catalogofcatalogsId, [FromServices] ICatalogsQuery query)
        {
            CatalogsResponse response = await query.RunAsync(catalogofcatalogsId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPost("CreateCatalogs")]
        [ProducesResponseType(201, Type = typeof(CatalogsResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCatalogs(CreateCatalogsRequest catalogofcatalogs, [FromServices] ICreateCatalogsCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CatalogsResponse response = await command.ExecuteAsync(catalogofcatalogs);
                return CreatedAtRoute("GetSingleCatalogs", new { catalogofcatalogsId = response.Id }, response);

            }
            catch (CannotCreateCatalogsExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut("UpdateCatalogs/{catalogofcatalogsId}")]
        [ProducesResponseType(201, Type = typeof(CatalogsResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> UpdateCatalogs(Guid catalogofcatalogsId, UpdateCatalogsRequest catalogofcatalogs, [FromServices] IUpdateCatalogsCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                CatalogsResponse response = await command.ExecuteAsync(catalogofcatalogsId, catalogofcatalogs);
                return CreatedAtRoute("GetSingleCatalogs", new { catalogofcatalogsId = response.Id }, response);

            }
            catch (CannotCreateCatalogsExeption exception)
            {
                foreach (var error in exception.Errors)
                {
                    ModelState.AddModelError(exception.Message, error.Description);
                }
                return BadRequest(ModelState);
            }

        }
        //[Authorize(Roles = "admin")]
        [HttpDelete("DeleteCatalogs/{catalogofcatalogsId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCatalogsAsync(Guid catalogofcatalogsId, [FromServices]IDeleteCatalogsCommand command)
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