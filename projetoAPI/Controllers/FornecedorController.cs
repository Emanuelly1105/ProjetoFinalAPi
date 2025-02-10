using atividadeapi;

namespace atividadeapi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using projetoAPI.DTO;
    using projetoAPI.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private static List<Fornecedor> fornecedores = new List<Fornecedor>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(fornecedores);
        }

        private bool ValidarCNPJ(string cnpj)
        {
            cnpj = Regex.Replace(cnpj, @"\D", "");
            return cnpj.Length == 14;
        }

        [HttpGet("{cnpj}")]
        public IActionResult GetByCNPJ(string cnpj)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = fornecedores.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FornecedorDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var cnpj = dto.CNPJ;
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            if (fornecedores.Any(f => f.CNPJ == cnpj))
            {
                return Conflict("Fornecedor existente.");
            }

            var fornecedor = new Fornecedor
            {
                NomeFantasia = dto.NomeFantasia,
                RazaoSocial = dto.RazaoSocial,
                CNPJ = cnpj,
                Endereco = dto.Endereco,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                Telefone = dto.Telefone,
                Email = dto.Email,
                Responsavel = dto.Responsavel
            };

            fornecedores.Add(fornecedor);

            return CreatedAtAction(nameof(GetByCNPJ), new { cnpj = fornecedor.CNPJ }, fornecedor);
        }

        [HttpPut("{cnpj}")]
        public IActionResult Put(string cnpj, [FromBody] FornecedorDTO dto)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido.");
            }

            var fornecedor = fornecedores.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound();
            }

            fornecedor.NomeFantasia = dto.NomeFantasia ?? fornecedor.NomeFantasia;
            fornecedor.RazaoSocial = dto.RazaoSocial ?? fornecedor.RazaoSocial;
            fornecedor.Endereco = dto.Endereco ?? fornecedor.Endereco;
            fornecedor.Cidade = dto.Cidade ?? fornecedor.Cidade;
            fornecedor.Estado = dto.Estado ?? fornecedor.Estado;
            fornecedor.Telefone = dto.Telefone ?? fornecedor.Telefone;
            fornecedor.Email = dto.Email ?? fornecedor.Email;
            fornecedor.Responsavel = dto.Responsavel ?? fornecedor.Responsavel;

            return Ok(fornecedor);
        }

        [HttpDelete("{cnpj}")]
        public IActionResult Deletar(string cnpj)
        {
            if (!ValidarCNPJ(cnpj))
            {
                return BadRequest("CNPJ inválido. Tente novamente!");
            }

            var fornecedor = fornecedores.FirstOrDefault(f => f.CNPJ == cnpj);

            if (fornecedor == null)
            {
                return NotFound();
            }

            fornecedores.Remove(fornecedor);

            return Ok(fornecedor);
        }
    }
}