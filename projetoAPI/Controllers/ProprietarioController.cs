using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoAPI.DTO;
using projetoAPI.Models;

namespace pds_projeto_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PropriedadeController : ControllerBase
    {
        List<Propriedade> listaPropriedades = new List<Propriedade>();

        public PropriedadeController()
        {
            var propriedade1 = new Propriedade()
            {
                Id = 1,
                NomePropriedade = "Fazenda Recanto Rural",
                NomeProprietario = "Iara Beatriz",
                TamanhoHectares = 150.5,
                CEP = 76900000,
                Logradouro = 123,
                Bairro = 456,
                Complemento = 789

            };

            listaPropriedades.Add(propriedade1);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaPropriedades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var propriedade = listaPropriedades.Where(item => item.Id == id).FirstOrDefault();

            if (propriedade == null)
            {
                return NotFound();
            }

            return Ok(propriedade);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PropriedadeDTO item)
        {
            var contador = listaPropriedades.Count();

            var propriedade = new Propriedade
            {
                Id = contador + 1,
                NomePropriedade = item.NomePropriedade,
                NomeProprietario = item.NomeProprietario,
                TamanhoHectares = item.TamanhoHectares,
                CEP = item.CEP,
                Logradouro = item.Logradouro,
                Bairro = item.Bairro,
                Complemento = item.Complemento
            };

            listaPropriedades.Add(propriedade);

            return StatusCode(StatusCodes.Status201Created, propriedade);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PropriedadeDTO item)
        {
            var propriedade = listaPropriedades.Where(item => item.Id == id).FirstOrDefault();

            if (propriedade == null)
            {
                return NotFound();
            }

            propriedade.NomePropriedade = item.NomePropriedade;
            propriedade.NomeProprietario = item.NomeProprietario;
            propriedade.TamanhoHectares = item.TamanhoHectares;
            propriedade.CEP = item.CEP;
            propriedade.Logradouro = item.Logradouro;
            propriedade.Bairro = item.Bairro;
            propriedade.Complemento = item.Complemento;

            return Ok(propriedade);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var propriedade = listaPropriedades.Where(item => item.Id == id).FirstOrDefault();

            if (propriedade == null)
            {
                return NotFound();
            }

            listaPropriedades.Remove(propriedade);

            return Ok(propriedade);
        }
    }
}