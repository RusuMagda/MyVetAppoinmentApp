﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly IDrugRepository drugRepository;
        private readonly IMapper mapper;

        public DrugsController(IDrugRepository drugRepository, IMapper mapper)
        {
            this.drugRepository = drugRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await drugRepository.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await drugRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDrugDto dto)
        {
            var drug = mapper.Map<Drug>(dto);
            await drugRepository.AddAsync(drug);
            drugRepository.Save();
            return Created(nameof(Get), drug);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var drug = await drugRepository.GetByIdAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            drugRepository.Delete(id);
            drugRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreateDrugDto dto)
        {
            var drug = await drugRepository.GetByIdAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            mapper.Map(dto, drug);
            drugRepository.Update(drug);
            drugRepository.Save();
            return NoContent();
        }

    }
}
