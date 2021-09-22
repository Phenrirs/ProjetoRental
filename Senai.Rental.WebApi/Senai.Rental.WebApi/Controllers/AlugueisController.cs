using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;

/// <summary>
/// Controlador responsável pelo end points referentes aos Alugueis!
/// </summary>
namespace Senai.Rental.WebApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON!
    [Produces("Application/json")]

    //Define a rota de uma requisição!
    [Route("api/[controller]")]

    //Define que é um controlador da API!
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface!
        /// </summary>
        private IAluguelRepository _AluguelRepository { get; set; }

        /// <summary>
        /// Instancia de um objeto para que haja referencia dos métodos no repositório
        /// </summary>
        //Construtor responsável pelos métodos do repositório dos aluguéis!
        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }


        //IActionResult = Resultado de uma ação!
        //Get() = nome generico!
        [HttpGet]
        public IActionResult GET()
        {
            List<AluguelDomain> ListaAlugueis = _AluguelRepository.ListarTodos();

            return Ok(ListaAlugueis);
        }

        [HttpGet("{idAluguel}")]
        public IActionResult GetByid(int idAluguel)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarId(idAluguel);

            if (AluguelBuscado == null)
            {
                return NotFound("Nenhum Aluguel foi encontrado");
            }

            return Ok(AluguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        [HttpPut("{idAluguel}")]
        public IActionResult Put(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarId(idAluguel);

            if (aluguelBuscado == null)
            {
                return NotFound
                (new
                {
                    mensagem = "Nenhum aluguel foi encontrado",
                    erro = true
                });
            }

            try
            {
                _AluguelRepository.AtualizarIdUrl(idAluguel, aluguelAtualizado);

                return NoContent();
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idAluguel}")]
        public IActionResult Delete(int idAluguel)
        {
            _AluguelRepository.Deletar(idAluguel);

            return StatusCode(204);
        }
    }
}
