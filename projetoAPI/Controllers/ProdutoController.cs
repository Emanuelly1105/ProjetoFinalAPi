using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetoAPI.DTO;
using projetoAPI.Models;

namespace CadastroPropriedadesAPI.Controllers
{
    [Route("produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        List<Produto> listaProdutos = new List<Produto>();

        public ProdutoController()
        {
            var produto1 = new Produto()
            {
                Id = 1,
                Nome = "Vacina",
                PrecoCusto = 240.00,
                Quantidade = 2,
                DataVencimento = new DateTime(2022, 11, 25),
                UnidadeEntrada = "Unidade",
                UnidadeSaida = "Unidade",
                PrecoVenda = 300.00,

            };

            listaProdutos.Add(produto1);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaProdutos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = listaProdutos.Where(item => item.Id == id).FirstOrDefault();

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO item)
        {
            var contador = listaProdutos.Count();

            var produto = new Produto
            {
                Id = contador + 1,
                Nome = item.Nome,
                PrecoCusto = item.PrecoCusto,
                Quantidade = item.Quantidade,
                DataVencimento = item.DataVencimento,
                UnidadeEntrada = item.UnidadeEntrada,
                UnidadeSaida = item.UnidadeSaida,
                PrecoVenda = item.PrecoVenda,
            };

            listaProdutos.Add(produto);

            return StatusCode(StatusCodes.Status201Created, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoDTO item)
        {
            var produto = listaProdutos.Where(item => item.Id == id).FirstOrDefault();

            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = item.Nome;
            produto.PrecoCusto = item.PrecoCusto;
            produto.Quantidade = item.Quantidade;
            produto.DataVencimento = item.DataVencimento;
            produto.UnidadeEntrada = item.UnidadeEntrada;
            produto.UnidadeSaida = item.UnidadeSaida;
            produto.PrecoVenda = item.PrecoVenda;

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = listaProdutos.Where(item => item.Id == id).FirstOrDefault();

            if (produto == null)
            {
                return NotFound();
            }

            listaProdutos.Remove(produto);

            return Ok(produto);
        }
    }
}