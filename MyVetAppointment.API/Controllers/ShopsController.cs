using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.API.Validators;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopRepository shopRepository;
        private readonly IMapper mapper;

        public ShopsController(IShopRepository shopRepository, IMapper mapper)
        {
            this.shopRepository = shopRepository;
            this.mapper = mapper;
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
            var shop = mapper.Map<Shop>(dto);
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
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreateShopDto dto)
        {
            var shop = await shopRepository.GetByIdAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            mapper.Map(dto, shop);
            shopRepository.Update(shop);
            shopRepository.Save();
            return NoContent();
        }
    }
}





