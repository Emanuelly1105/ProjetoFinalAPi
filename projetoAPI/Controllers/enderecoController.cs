namespace endereço_api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using projetoAPI.DTO;
    using projetoAPI.Models;
    using System.Collections.Generic;
    using System.Linq;
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private static List<endereco> enderecos = new List<endereco>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(enderecos);
        }

        [HttpGet("{cep}")]
        public IActionResult GetByCEP(string cep)
        {
            var endereco = enderecos.FirstOrDefault(e => e.CEP == cep);

            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            return Ok(endereco);
        }

        [HttpPost]
        public IActionResult Post([FromBody] enderecoDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.CEP))
            {
                return BadRequest("Dados inválidos ou CEP ausente.");
            }

            if (enderecos.Any(e => e.CEP == dto.CEP))
            {
                return Conflict("Endereço já cadastrado.");
            }

            var endereco = new endereco
            {
                Rua = dto.Rua,
                Numero = dto.Numero,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                CEP = dto.CEP
            };

            enderecos.Add(endereco);

            return CreatedAtAction(nameof(GetByCEP), new { cep = endereco.CEP }, endereco);
        }

        [HttpPut("{cep}")]
        public IActionResult Put(string cep, [FromBody] enderecoDTO dto)
        {
            var endereco = enderecos.FirstOrDefault(e => e.CEP == cep);

            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            endereco.Rua = dto.Rua ?? endereco.Rua;
            endereco.Numero = dto.Numero ?? endereco.Numero;
            endereco.Bairro = dto.Bairro ?? endereco.Bairro;
            endereco.Cidade = dto.Cidade ?? endereco.Cidade;
            endereco.Estado = dto.Estado ?? endereco.Estado;
            endereco.CEP = dto.CEP ?? endereco.CEP;

            return Ok(endereco);
        }

        [HttpDelete("{cep}")]
        public IActionResult Delete(string cep)
        {
            var endereco = enderecos.FirstOrDefault(e => e.CEP == cep);

            if (endereco == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            enderecos.Remove(endereco);

            return Ok(endereco);
        }
    }
}