using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerDeVehiculosApi.DTO.Empleado;

namespace TallerDeVehiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepository<Empleado> _repository;

        public EmpleadosController(IRepository<Empleado> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpleadoCreateDTO model)
        {
            var result = await _repository.AddAsync(Mapper.Map<Empleado>(model));
            return CreatedAtRoute("GetEmpleado", new { id = result.Id}, result);
        }

        [HttpGet("{id}", Name = "GetEmpleado")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoCreateDTO model)
        {
            var result =  await _repository.GetByIdAsync(id);

            if (result == null) return NotFound($"El empleado con el id {id} no existe");

            await _repository.UpdateAsync(Mapper.Map<Empleado>(model));
            return NoContent();
        }
    }
}