
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoAPI.DTO;
using projetoAPI.Models;

namespace api_Aparicao.Controllers
{
    [Route("aparicao")]
    [ApiController]
    public class ApartacaoController : ControllerBase
    {
        List<Aparicao> listaApartacoes = new List<Aparicao>();

        public ApartacaoController()
        {
            var aparicao1 = new Aparicao()
            {
               
                Propriedade = "Fazenda Rancho rural",
                Pasto = "Ruicem Apartados",
                Animal = "Vaquinha mimosa",
                Situacao = "Natural",
                Observacao = "Nenhuma",
                TransferirParaLote = "Lote A",
                DataTransferenciaLote = new DateTime(2022, 11, 25)
            };

            listaApartacoes.Add(aparicao1);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaApartacoes);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var apartacao = listaApartacoes.Where(item => item.Id == id).FirstOrDefault();

            if (apartacao == null)
            {
                return NotFound();
            }

            return Ok(apartacao);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AparicaoDTO item)
        {
            var contador = listaApartacoes.Count();

            var apartacao = new Aparicao
            {
                Id = contador + 1,
                Propriedade = item.Propriedade,
                Pasto = item.Pasto,
                Animal = item.Animal,
                Situacao = item.Situacao,
                Observacao = item.Observacao,
                TransferirParaLote = item.TransferirParaLote,
                DataTransferenciaLote = item.DataTransferenciaLote
            };

            listaApartacoes.Add(apartacao);

            return StatusCode(StatusCodes.Status201Created, apartacao);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AparicaoDTO item)
        {
            var apartacao = listaApartacoes.Where(item => item.Id == id).FirstOrDefault();

            if (apartacao == null)
            {
                return NotFound();
            }

            apartacao.Propriedade = item.Propriedade;
            apartacao.Pasto = item.Pasto;
            apartacao.Animal = item.Animal;
            apartacao.Situacao = item.Situacao;
            apartacao.Observacao = item.Observacao;
            apartacao.TransferirParaLote = item.TransferirParaLote;
            apartacao.DataTransferenciaLote = item.DataTransferenciaLote;

            return Ok(apartacao);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var apartacao = listaApartacoes.Where(item => item.Id == id).FirstOrDefault();

            if (apartacao == null)
            {
                return NotFound();
            }

            listaApartacoes.Remove(apartacao);

            return Ok(apartacao);
        }
    }
}