using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Services;
using Shop.BLL.DTO;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthUserDTO>> Register(NewUserDTO request)
        {
            var user = await userService.CreateUser(request);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUserDTO>> Login(LoginUserDTO request)
        {
            var user = await authService.Authorize(request);

            return Ok(user);
        }
    }
}
