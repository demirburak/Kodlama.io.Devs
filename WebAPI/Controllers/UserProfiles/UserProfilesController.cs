using Application.Features.UserProfiles.Commands;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Models;
using Application.Features.UserProfiles.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.UserProfiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            return Ok("Api is working...");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            CreatedUserProfileDto createdUserProfileDto = await Mediator.Send(createUserProfileCommand);
            return Created("", createdUserProfileDto);
        }

        [Authorize]
        [HttpPost("AddWithAuthorize")]
        public async Task<IActionResult> AddWithAuthorizeAsync([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            CreatedUserProfileDto createdUserProfileDto = await Mediator.Send(createUserProfileCommand);
            return Created("", createdUserProfileDto);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserProfileCommand UpdateUserProfileCommand)
        {
            UpdatedUserProfileDto UpdatedUserProfileDto = await Mediator.Send(UpdateUserProfileCommand);
            return Ok(UpdatedUserProfileDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserProfileCommand DeleteUserProfileCommand)
        {
            DeletedUserProfileDto DeletedUserProfileDto = await Mediator.Send(DeleteUserProfileCommand);
            return Ok(DeletedUserProfileDto);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            GetListUserProfileQuery getListUserProfileQuery = new() { PageRequest = pageRequest };

            UserProfileListModel UserProfileListModel = await Mediator.Send(getListUserProfileQuery);
            return Ok(UserProfileListModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int Id)
        {
            GetByIdUserProfileQuery getByIdUserProfileQuery = new() {  Id = Id };

            UserProfileGetByIdDto UserProfileGetByIdDto = await Mediator.Send(getByIdUserProfileQuery);
            return Ok(UserProfileGetByIdDto);
        }


    }
}
