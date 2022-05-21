using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.BLL.Services;
using Shop.BLL.DTO;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public AuthContoller(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthUserDTO>> Register(newUserDTO request)
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
