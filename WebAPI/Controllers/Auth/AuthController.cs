using Application.Features.Authentication.Commands;
using Application.Features.Authentication.Dtos;
using Application.Features.Authentication.Queries;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Application.Features.Techs.Commands;
using Application.Features.Techs.Dtos;
using Application.Features.Techs.Models;
using Application.Features.Techs.Queries;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            return Ok("Api is working...");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserCommand registerUserCommand)
        {
            RegistrationDto registerUserDto = await Mediator.Send(registerUserCommand);
            return Created("", registerUserDto);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestQuery loginRequestQuery)
        {
            LoginResultDto loginResultDto = await Mediator.Send(loginRequestQuery);
            return Ok(loginResultDto);
        }

    }
}
