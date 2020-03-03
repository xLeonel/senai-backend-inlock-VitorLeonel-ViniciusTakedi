using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // private IJogoRepository _jogoRepository { get; set; }
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            // _jogoRepository = new JogoRepository();
            _usuarioRepository = new UsuarioRepository();
        }

        // Listar Jogos 
        // [HttpGet]
        // public IActionResult ListarTodosJogos()
        // {
        //     return Ok(_jogosRepository.ListarTodosJogos());
        // }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return Ok(_usuarioRepository.ListarUsuarios());
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, UsuarioDomain usuario)
        {
            _usuarioRepository.Atualizar(id, usuario);
            return Ok("Atualizado");
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
