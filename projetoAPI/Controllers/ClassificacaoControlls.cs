using Microsoft.AspNetCore.Mvc;
using projetoAPI.DTO;
using projetoAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_classificacao.Controllers
{
    [Route("api/classificacao")]
    [ApiController]
    public class ClassificacaoAnimalController : ControllerBase
    {
        private static List<Classificacao> listaClassificacaoAnimal = new List<Classificacao>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaClassificacaoAnimal);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classificacaoAnimal = listaClassificacaoAnimal.FirstOrDefault(c => c.Id == id);
            if (classificacaoAnimal == null)
            {
                return NotFound();
            }
            return Ok(classificacaoAnimal);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClassificacaoDTO dto)
        {
            var novaClassificacaoAnimal = new Classificacao
            {
                Id = listaClassificacaoAnimal.Count + 1,
                NomeGrupo = dto.NomeGrupo,
                fase = dto.fase,
                sexo = dto.sexo,
                delimitacaoGrupo = dto.delimitacaoGrupo,
                producaoleiteminima = dto.producaoleiteminima,
                producaoleitemaxima = dto.producaoleitemaxima,
                descricaogrupo = dto.descricaogrupo
            };

            listaClassificacaoAnimal.Add(novaClassificacaoAnimal);
            return StatusCode(201, novaClassificacaoAnimal);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClassificacaoDTO dto)
        {
            var classificacaoAnimal = listaClassificacaoAnimal.FirstOrDefault(c => c.Id == id);
            if (classificacaoAnimal == null)
            {
                return NotFound();
            }

            classificacaoAnimal.NomeGrupo = dto.NomeGrupo;
            classificacaoAnimal.fase = dto.fase;
            classificacaoAnimal.sexo = dto.sexo;
            classificacaoAnimal.delimitacaoGrupo = dto.delimitacaoGrupo;
            classificacaoAnimal.producaoleiteminima = dto.producaoleiteminima;
            classificacaoAnimal.producaoleitemaxima = dto.producaoleitemaxima;
            classificacaoAnimal.descricaogrupo = dto.descricaogrupo;

            return Ok(classificacaoAnimal);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var classificacaoAnimal = listaClassificacaoAnimal.FirstOrDefault(c => c.Id == id);
            if (classificacaoAnimal == null)
            {
                return NotFound();
            }

            listaClassificacaoAnimal.Remove(classificacaoAnimal);
            return Ok(classificacaoAnimal);
        }
    }
}