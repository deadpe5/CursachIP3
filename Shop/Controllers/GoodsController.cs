using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.DTO;
using Shop.BLL.Services;
using System.Text.Json;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService goodsService;
        public GoodsController(IGoodsService goodsService)
        {
            this.goodsService = goodsService;
        }

        [HttpPost("createGood"), Authorize(Roles = "Moderator")]
        public async Task<ActionResult> CreateGoods(newGoodsDTO request)
        {
            await goodsService.CreateGoods(request);

            return Ok();
        }

        [HttpDelete("deleteGoods"), Authorize(Roles = "Moderator")]
        public async Task<ActionResult> DeleteGoods(int request)
        {
            await goodsService.DeleteGoods(request);

            return Ok();
        }

        [HttpPut("updateGoods"), Authorize(Roles = "Moderator")]
        public async Task<ActionResult> UpdateGoods(updatedGoodsDTO request)
        {
            await goodsService.UpdateGoods(request);

            return Ok();
        }

        [HttpGet("getAllGoods"), Authorize(Roles = "Client, Moderator")]
        public async Task<ActionResult> GetAllGoods()
        {
           var goods = await goodsService.GetAllGoodsList();

            return Ok(goods);
        }

        [HttpGet("getAllGoodsByFilter"), Authorize(Roles = "Client, Moderator")]
        public async Task<ActionResult> GetAllGoodsByFilter(string request)
        {
            var filter = JsonSerializer.Deserialize<FilterDTO>(request);
            var goods = await goodsService.GetGoodsByFilter(filter);

            return Ok(goods);
        }

    }
}
