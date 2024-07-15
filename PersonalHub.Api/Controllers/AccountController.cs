using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalHub.Application.DTOs;
using PersonalHub.Application.Services;

namespace PersonalHub.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] CreateApiUserDto createApiUserDto)
        {
            var errors = await _authService.Register(createApiUserDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginApiUserDto loginApiUserDto)
        {
            var isValidUser = await _authService.AuthenticateUser(loginApiUserDto);

            if (!isValidUser)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
