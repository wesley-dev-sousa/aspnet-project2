using App.Application.Services;
using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Produces("application/json")]
    [Route("pessoa")]
    public class PessoaController : Controller
    {
        private IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }
        [HttpPost("Criar")]
        public IActionResult Criar([FromBody] Pessoa pessoa)
        {
            try
            {
                _pessoaService.Criar(pessoa);
                return Json(RetornoApi.Sucesso("Pessoa criada com sucesso!"));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] Pessoa pessoa)
        {
            try
            {
                _pessoaService.Editar(pessoa);
                return Json(RetornoApi.Sucesso("Pessoa editada com sucesso!"));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpDelete("Deletar")]
        public IActionResult Deletar([FromHeader] int id)
        {
            try
            {
                _pessoaService.Deletar(id);
                return Json(RetornoApi.Sucesso("Pessoa deletada com sucesso!"));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId([FromHeader] int id)
        {
            try
            {
                var pessoa = _pessoaService.BuscarPorId(id);
                return Json(RetornoApi.Sucesso(pessoa));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpGet("BuscarLista")]
        public IActionResult BuscarLista()
        {
            try
            {
                var listaPessoas = _pessoaService.BuscarLista();
                return Json(RetornoApi.Sucesso(listaPessoas));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
