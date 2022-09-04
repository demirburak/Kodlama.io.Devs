using Application.Features.ProgramLanguages.Commands;
using Application.Features.ProgramLanguages.Dtos;
using Application.Features.ProgramLanguages.Models;
using Application.Features.ProgramLanguages.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ProgramLanguages
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramLanguagesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            return Ok("Api is working...");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateProgramLanguageCommand createProgramLanguageCommand)
        {
            CreatedProgramLanguageDto createdProgramLanguageDto = await Mediator.Send(createProgramLanguageCommand);
            return Created("", createdProgramLanguageDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProgramLanguageCommand UpdateProgramLanguageCommand)
        {
            UpdatedProgramLanguageDto UpdatedProgramLanguageDto = await Mediator.Send(UpdateProgramLanguageCommand);
            return Ok(UpdatedProgramLanguageDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteProgramLanguageCommand DeleteProgramLanguageCommand)
        {
            DeletedProgramLanguageDto DeletedProgramLanguageDto = await Mediator.Send(DeleteProgramLanguageCommand);
            return Ok(DeletedProgramLanguageDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            GetListProgramLanguageQuery getListProgramLanguageQuery = new() { PageRequest = pageRequest };

            ProgramLanguageListModel programLanguageListModel = await Mediator.Send(getListProgramLanguageQuery);
            return Ok(programLanguageListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int Id)
        {
            GetByIdProgramLanguageQuery getByIdProgramLanguageQuery = new() { LanguageId = Id };

            ProgramLanguageGetByIdDto programLanguageGetByIdDto = await Mediator.Send(getByIdProgramLanguageQuery);
            return Ok(programLanguageGetByIdDto);
        }
       
        
    }
}
