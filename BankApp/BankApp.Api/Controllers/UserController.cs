using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService;
using static UserService.UserServiceClient;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServiceClient _userServiceClient;

        public UserController()
        {
            EndpointAddress address = new EndpointAddress("http://localhost:61700/Services/UserService.svc");
            _userServiceClient = new UserServiceClient(EndpointConfiguration.BasicHttpBinding_IUserService, address);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userServiceClient.AuthenticateUserAsync("test1User", "test1Password").ConfigureAwait(false));
        }
    }
}