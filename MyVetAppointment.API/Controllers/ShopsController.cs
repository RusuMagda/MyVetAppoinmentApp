﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.API.Validators;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopRepository shopRepository;
        private readonly IMapper mapper;
        private readonly ShopValidator _validator = new ShopValidator();

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
            var validationResult = await _validator.ValidateAsync(shop);
            if (validationResult.Errors.Count > 0)
                return BadRequest(validationResult.Errors);
            else
            {
                await shopRepository.AddAsync(shop);
                shopRepository.Save();
                return Created(nameof(GetAsync), shop);
            }
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
