using Application.Features.Models.Queries.GetListModelByDynamic;
using Application.Features.Techs.Commands;
using Application.Features.Techs.Dtos;
using Application.Features.Techs.Models;
using Application.Features.Techs.Queries;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Techs
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            return Ok("Api is working...");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateTechCommand createTechCommand)
        {
            RegisterUserDto createdTechDto = await Mediator.Send(createTechCommand);
            return Created("", createdTechDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateTechCommand UpdateTechCommand)
        {
            UpdatedTechDto UpdatedTechDto = await Mediator.Send(UpdateTechCommand);
            return Ok(UpdatedTechDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteTechCommand DeleteTechCommand)
        {
            DeletedTechDto DeletedTechDto = await Mediator.Send(DeleteTechCommand);
            return Ok(DeletedTechDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            GetListTechQuery getListTechQuery = new() { PageRequest = pageRequest };

            TechListModel TechListModel = await Mediator.Send(getListTechQuery);
            return Ok(TechListModel);
        }

        [HttpPost("GetListByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListTechByDynamicQuery getListTechByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            TechListModel result = await Mediator.Send(getListTechByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int Id)
        {
            GetByIdTechQuery getByIdTechQuery = new() {  Id = Id };

            TechGetByIdDto TechGetByIdDto = await Mediator.Send(getByIdTechQuery);
            return Ok(TechGetByIdDto);
        }
       
        
    }
}
