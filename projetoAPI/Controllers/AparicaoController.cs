
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
          

        [HttpGet]
        public IActionResult Get()
        {
            var Aparicao = new AparicaoDAO().List();

            return Ok(Aparicao);
        }

        

        [HttpPost]
        public IActionResult Post([FromBody] AparicaoDTO item)
        {
            var Aparicao = new Aparicao(); 

            Aparicao.Id = item.Id;
            Aparicao.Propriedade = item.Propriedade;
            Aparicao.Pasto = item.Pasto;
            Aparicao.Animal = item.Animal;
            Aparicao.Situacao = item.Situacao;
            Aparicao.Observacao = item.Observacao;
            Aparicao.TransferirParaLote = item.TransferirParaLote;
            Aparicao.DataTransferenciaLote = item.DataTransferenciaLote;
                

            try
            {
                var dao = new AparicaoDAO();
                Aparicao.Id = dao.Insert(Aparicao);
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Created("", Aparicao);



        }

        
       
    }
}