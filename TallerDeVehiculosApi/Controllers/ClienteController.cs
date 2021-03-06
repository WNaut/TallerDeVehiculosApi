﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerDeVehiculosApi.DTO.Cliente;

namespace TallerDeVehiculosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteController(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteCreateDTO model)
        {
            var result = await _repository.AddAsync(Mapper.Map<Cliente>(model));
            return CreatedAtRoute("GetCliente", new { id = result.Id }, result);
        }

        [HttpGet("{id}", Name = "GetCliente")]
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
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteCreateDTO model)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null) return NotFound($"El Cliente con el id {id} no existe");

            await _repository.UpdateAsync(Mapper.Map<Cliente>(model));
            return NoContent();
        }
    }
}