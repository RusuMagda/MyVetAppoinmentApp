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

        public DrugsController(IDrugRepository drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(drugRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(drugRepository.Get(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateDrugDto dto)
        {
            var drug = new Drug(dto.DrugName, dto.Description, dto.Stock, dto.Price, dto.SaleForm,
                                dto.Quantity, dto.QuantityMeasure);
            drugRepository.Add(drug);
            drugRepository.Save();
            return Created(nameof(Get), drug);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var drug = drugRepository.Get(id);
            if (drug == null)
            {
                return NotFound();
            }
            drugRepository.Delete(drug);
            drugRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreateDrugDto dto)
        {
            var drug = drugRepository.Get(id);
            if (drug == null)
            {
                return NotFound();
            }
            drugRepository.Update(new Drug(dto.DrugName, dto.Description, dto.Stock, dto.Price, dto.SaleForm,
                                dto.Quantity, dto.QuantityMeasure));
            drugRepository.Save();
            return NoContent();
        }

    }
}
