using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopRepository shopRepository;

        public ShopsController(IShopRepository shopRepository)
        {
            this.shopRepository = shopRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await shopRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var shop = await shopRepository.GetByIdAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateShopDto dto)
        {
            var shop = new Shop(dto.ShopName,dto.CabinetId);
            await shopRepository.AddAsync(shop);
            shopRepository.Save();
            return Created(nameof(GetAsync), shop);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var shop = await shopRepository.GetByIdAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            shopRepository.Delete(id);
            shopRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateShopDto dto)
        {
            var shop = await shopRepository.GetByIdAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            shop.ShopName = dto.ShopName;
            shopRepository.Update(shop);
            shopRepository.Save();
            return NoContent();
        }
    }
}
