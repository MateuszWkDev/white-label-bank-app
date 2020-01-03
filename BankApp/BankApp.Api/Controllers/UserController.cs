using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServiceClient;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userServiceClient, ILogger<UserController> logger)
        {
            _userServiceClient = userServiceClient;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Test login method");
            var tasks = new[] { _userServiceClient.AuthenticateUserAsync("test1User", "test1Password"), _userServiceClient.AuthenticateUserAsync("test1User", "test1Password") };
            return Ok(await Task.WhenAll(tasks).ConfigureAwait(false));
        }
    }
}