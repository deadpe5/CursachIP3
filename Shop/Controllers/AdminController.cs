using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Services;
using Shop.BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly IUserService userService;

        public AdminController(IAdminService adminService, IUserService userService)

        {
            this.userService = userService;
            this.adminService = adminService;
        }

        [HttpPost("addSupplier"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> AddSupplier(NewSupplierDTO request)
        {
            await adminService.CreateSupplier(request);

            return Ok();
        }

        [HttpDelete("removeSupplier"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> RemoveSupplier(string request)
        {
            await adminService.DeleteSupplier(request);

            return Ok();
        }

        [HttpPut("updateSupplier"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateSupplier(SupplierDTO request)
        {
            await adminService.UpdateSupplier(request);

            return Ok();
        }

        [HttpGet("getSuppliers"), Authorize(Roles = "Administrator, Moderator")]
        public async Task<ActionResult> GetAllSuppliers()
        {
            var suppliers = await adminService.GetAllSuppliersList();
            return Ok(suppliers);
        }

        [HttpGet("getSuppliersByName"), Authorize(Roles = "Administrator, Moderator")]
        public async Task<ActionResult> GetSuppliersByName(string request)
        {
            var suppliers = await adminService.GetSuppliersByName(request);
            return Ok(suppliers);
        }

        [HttpGet("getUsers"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersList();
            return Ok(users);
        }

        [HttpGet("getUsersByName"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllUsersByName(string request)
        {
            var users = await userService.GetUsersByName(request);
            return Ok(users);
        }
        [HttpPut("toggleUserRole"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> ToggleUserRole(string request)
        {
            await userService.ToggleRole(request);
            return Ok();
        }

        [HttpDelete("removeUser"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> RemoveUser(string request)
        {
            await userService.DeleteUser(request);

            return Ok();
        }

        [HttpGet("getCompanyInfo"), Authorize(Roles = "Administrator, Moderator")]
        public ActionResult GetCompanyInfo()
        {
            return Ok(adminService.GetCompanyInfo());
        }
    }
}
