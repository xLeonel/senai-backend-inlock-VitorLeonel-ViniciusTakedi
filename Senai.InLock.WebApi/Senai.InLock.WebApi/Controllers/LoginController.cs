using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel Usuario)
        {
            UsuarioDomain usuarioSelecionado = _usuarioRepository.BuscarPorEmailSenha(Usuario.Email, Usuario.Senha);

            if (usuarioSelecionado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            
            return Ok();
        }
    }
}