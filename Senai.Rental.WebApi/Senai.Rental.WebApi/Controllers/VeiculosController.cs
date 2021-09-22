using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;

/// <summary>
/// 
/// </summary>
namespace Senai.Rental.WebApi.Controllers
{
    [Produces ("Application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class VeiculosController : ControllerBase
    {

        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult GET()
        {
            
            List<VeiculoDomain> ListaVeiculos = _VeiculoRepository.ListarTodos();

            return Ok(ListaVeiculos);
        }

        [HttpGet("{idVeiculo}")]
        public IActionResult GetByid(int idVeiculo)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarId(idVeiculo);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nenhum Veiculo foi encontrado");
            }

            return Ok(VeiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{idVeiculo}")]
        public IActionResult Put(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarId(idVeiculo);

            if (VeiculoBuscado == null)
            {
                return NotFound
                (new
                {
                    mensagem = "Nenhum Veiculo foi encontrado",
                    erro = true
                });
            }

            try
            {
                _VeiculoRepository.AtualizarIdUrl(idVeiculo, veiculoAtualizado);

                return NoContent();
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idVeiculo}")]
        public IActionResult Delete(int idVeiculo)
        {
            _VeiculoRepository.Deletar(idVeiculo);

            return StatusCode(204);
        }
    }
}
