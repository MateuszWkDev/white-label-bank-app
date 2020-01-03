using System.Threading.Tasks;
using BankApp.Api.Models;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "There is no authentication data" });
            }

            var user = await _userService.AuthenticateUserAsync(model.Username, model.Password).ConfigureAwait(false);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
    }
}