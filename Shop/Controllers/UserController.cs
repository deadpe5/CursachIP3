using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.DTO;
using Shop.BLL.Services;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("getUserByEmail"), Authorize (Roles = "Client, Moderator")]
        public async Task<ActionResult> GetUserByEmail(string request)
        {
            var user = await userService.GetUserByEmail(request);

            return Ok(user);
        }

        [HttpPut("updateUser"), Authorize(Roles = "Client, Moderator")]
        public async Task<ActionResult> UpdateUser(UserDTO request)
        {
            var user = await userService.UpdateUser(request);

            return Ok(user);
        }

        [HttpPut("updadePassword"), Authorize(Roles = "Client, Moderator")]
        public async Task<ActionResult> UpdatePassword(NewPasswordDTO request)
        {
            await userService.ChangePassword(request);

            return Ok();
        }
    }
}
