using App.Application.Services;
using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers {

    [Produces("application/json")]
    [Route("pokemon")]
    public class PokemonController : Controller {
        private IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService) {
            _pokemonService = pokemonService;
        }
        [HttpPost("criar")]
        public IActionResult Criar([FromBody] Pokemon pokemon) {
            try {
                _pokemonService.Criar(pokemon);
                return Json(RetornoApi.Sucesso("Pokemon criado com sucesso!"));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPut("editar")]
        public IActionResult Editar([FromBody] Pokemon pokemon) {
            try {
                _pokemonService.Editar(pokemon);
                return Json(RetornoApi.Sucesso("Pokemon editado com sucesso!"));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("deletar")]
        public IActionResult Deletar([FromHeader] int id) {
            try {
                _pokemonService.Deletar(id);
                return Json(RetornoApi.Sucesso("Pessoa deletada com sucesso!"));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("buscarPorId")]
        public IActionResult BuscarPorId([FromHeader] int id) {
            try {
                var pokemon = _pokemonService.BuscarPorId(id);
                return Json(RetornoApi.Sucesso(pokemon));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }


        [HttpGet("buscarPorNome")]
        public IActionResult BuscarPorNome([FromHeader] string nome) {
            try {
                var pokemon = _pokemonService.BuscarPorNome(nome);
                return Json(RetornoApi.Sucesso(pokemon));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }


        [HttpGet("buscarLista")]
        public IActionResult BuscarLista() {
            try {
                var listaPokemons = _pokemonService.BuscarLista();
                return Json(RetornoApi.Sucesso(listaPokemons));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

    }
}
