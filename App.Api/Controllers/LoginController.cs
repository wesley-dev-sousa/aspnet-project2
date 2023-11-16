using App.Domain.DTO;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers {
    [Produces("application/json")]
    [Route("login")]
    public class LoginController : Controller {

        private readonly ILoginService _service;
        public LoginController(ILoginService service) {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPost("Logar")]
        public IActionResult Logar([FromBody] PessoaDTO pessoa) {
            pessoa = _service.Logar(pessoa);
            return Json(RetornoApi.Sucesso(pessoa));
        }
        [Authorize]
        [HttpGet("GetLogado")]
        public IActionResult GetLogado([FromHeader]PessoaDTO pessoa) {
            return Ok();
        }
    }
}
