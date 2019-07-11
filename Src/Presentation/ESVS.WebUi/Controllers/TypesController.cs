using System;
using System.Threading.Tasks;
using ESVS.Application.Catalogs.Queries;
using ESVS.Application.Catalogs.Queries.GetListCatalogs;
using ESVS.Application.Infrastructure.Query;
using ESVS.Application.Types;
using ESVS.Application.Types.Commands.CreateType;
using ESVS.Application.Types.Queries.GetListTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESVS.WebUi.Controllers
{
    public class TypesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListResponse<TypeViewModel>>> GetAll([FromQuery]GetListTypesQuery query) =>

            Ok(await Mediator.Send(query));


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTypeCommand command)
        {
            var productId = await Mediator.Send(command);
            return Ok(productId);
        }
    }
}