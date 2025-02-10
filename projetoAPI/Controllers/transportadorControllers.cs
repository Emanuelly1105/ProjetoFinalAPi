using Microsoft.AspNetCore.Mvc;

namespace APItransportador.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using projetoAPI.DTO;
    using projetoAPI.Models;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/transportador")]
    [ApiController]
    public class TransportadorController : ControllerBase
    {
        private static List<transportador> listaTransportador = new List<transportador>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaTransportador);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transportador = listaTransportador.FirstOrDefault(t => t.Id == id);
            if (transportador == null)
            {
                return NotFound();
            }
            return Ok(transportador);
        }

        [HttpPost]
        public IActionResult Post([FromBody] transportadorDTO dto)
        {
            var novoTransportador = new transportador
            {
                Id = listaTransportador.Count + 1,
                Nome = dto.Nome,
                CpfCnpj = dto.CpfCnpj,
                Estado = dto.Estado,
                Cep = dto.Cep,
                Cidade = dto.Cidade,
                Rua = dto.Rua,
                Bairro = dto.Bairro
            };

            listaTransportador.Add(novoTransportador);
            return StatusCode(201, novoTransportador);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] transportadorDTO dto)
        {
            var transportador = listaTransportador.FirstOrDefault(t => t.Id == id);
            if (transportador == null)
            {
                return NotFound();
            }

            transportador.Nome = dto.Nome;
            transportador.CpfCnpj = dto.CpfCnpj;
            transportador.Estado = dto.Estado;
            transportador.Cep = dto.Cep;
            transportador.Cidade = dto.Cidade;
            transportador.Rua = dto.Rua;
            transportador.Bairro = dto.Bairro;

            return Ok(transportador);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transportador = listaTransportador.FirstOrDefault(t => t.Id == id);
            if (transportador == null)
            {
                return NotFound();
            }

            listaTransportador.Remove(transportador);
            return Ok(transportador);
        }
    }
}