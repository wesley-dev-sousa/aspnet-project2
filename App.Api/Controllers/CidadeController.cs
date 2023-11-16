using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : Controller {
        private ICidadeService _service;

        public CidadeController(ICidadeService service) {
            _service = service;
        }

        [HttpGet("ListaCidades")]
        [AllowAnonymous]
        public JsonResult ListaCidades(string busca) {
            try {
                var obj = _service.listaCidades(busca);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id) {
            try {
                var obj = _service.BuscaPorId(id);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpPost("Salvar")]
        public JsonResult Salvar([FromBody] Cidade obj) {
            try {
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("Remover")]
        public JsonResult Remover(Guid id) {
            try {
                _service.Remover(id);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}