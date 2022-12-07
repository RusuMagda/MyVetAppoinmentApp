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
        public IActionResult Get()
        {
            return Ok(shopRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var shop = shopRepository.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateShopDto dto)
        {
            var shop = new Shop(dto.ShopName,dto.CabinetId);
            shopRepository.Add(shop);
            shopRepository.Save();
            return Created(nameof(Get), shop);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var shop = shopRepository.Get(id);
            if (shop == null)
            {
                return NotFound();
            }
            shopRepository.Delete(shop);
            shopRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreateShopDto dto)
        {
            var shop = shopRepository.Get(id);
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
