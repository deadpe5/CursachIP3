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

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost("addSupplier"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> AddSupplier(newSupplierDTO request)
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

        [HttpGet("getSuppliers"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAllSuppliers()
        {
            var q = await adminService.GetAllSuppliersList();
            return Ok(q);
        }

        [HttpGet("getSuppliersByName"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetSuppliersByName(string request)
        {
            var q = await adminService.GetSuppliersByName(request);
            return Ok(q);
        }

        [HttpGet("getCompanyInfo"), Authorize(Roles = "Administrator, Moderator")]
        public ActionResult GetCompanyInfo()
        {
            return Ok(adminService.GetCompanyInfo());
        }
    }
}
