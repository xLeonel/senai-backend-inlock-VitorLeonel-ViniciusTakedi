using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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


        /// <summary>
        /// Listar Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return Ok(_usuarioRepository.ListarUsuarios());
        }

        /// <summary>
        /// Cadastar Usuarios
        /// </summary>
        /// <param></param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            _usuarioRepository.Cadastar(usuario);
            return Created("Criado", usuario);
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


        /// <summary>
        /// Deleta usuario
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Deletado");
        }
    }
}
