namespace ApiEquipamento.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using projetoAPI.DTO;
    using projetoAPI.Models;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        List<Equipamento> equipamentos= new List<Equipamento>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(equipamentos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EquipamentoDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var equipamento = new Equipamento
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Codigo = dto.Codigo,
                Quantidade = dto.Quantidade,
                Valor = dto.Valor,
                Fornecedor = dto.Fornecedor,
                Marca = dto.Marca,
                Ano = dto.Ano,
                Estado = dto.Estado
            };

            equipamentos.Add(equipamento);

            
            return CreatedAtAction(nameof(GetByCodigo), new { codigo = equipamento.Codigo }, equipamento);
        }

        [HttpGet("{codigo}")]
        public IActionResult GetByCodigo(string codigo)
        {
            var equipamento = equipamentos.FirstOrDefault(e => e.Codigo == codigo);

            if (equipamento == null)
            {
                return NotFound();
            }

            return Ok(equipamento);
        }

        [HttpPut("{codigo}")]
        public IActionResult Put(string codigo, [FromBody] EquipamentoDTO dto)
        {
            var equipamento = equipamentos.FirstOrDefault(e => e.Codigo == codigo);

            if (equipamento == null)
            {
                return NotFound();
            }


            equipamento.Nome = dto.Nome ?? equipamento.Nome;
            equipamento.Descricao = dto.Descricao ?? equipamento.Descricao;
            equipamento.Quantidade = dto.Quantidade ?? equipamento.Quantidade;
            equipamento.Valor = dto.Valor ?? equipamento.Valor;
            equipamento.Fornecedor = dto.Fornecedor ?? equipamento.Fornecedor;
            equipamento.Marca = dto.Marca ?? equipamento.Marca;     
            equipamento.Ano = dto.Ano ?? equipamento.Ano;           
            equipamento.Estado = dto.Estado ?? equipamento.Estado;   

            return Ok(equipamento);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(string codigo)
        {
            var equipamento = equipamentos.FirstOrDefault(e => e.Codigo == codigo);

            if (equipamento == null)
            {
                return NotFound();
            }

            equipamentos.Remove(equipamento);

            return Ok(equipamento);
        }
    }


}