using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    namespace Senai.InLock.WebApi.Controllers
    {
            [Produces("application/json")]
            [Route("api/[controller]")]
    
            [ApiController]
            public class JogoController : ControllerBase
            {
                private IJogoRepository _jogoRepository { get; set; }
                public JogoController()
                {
                    _jogoRepository = new JogoRepository();
                }

            /// <summary>
            /// Atualiza um jogo passando o seu id na url
            /// </summary>
            /// <param name="id"></param>
            /// <param name="jogoAtualizado"></param>
            /// <returns>null</returns>
            [Authorize(Roles = "1")]
            [HttpPut("{id}")]
            public IActionResult PutIdUrl(int id, JogoDomain jogoAtualizado)
            {
                _jogoRepository.AtualizarJogoIdUrl(id, jogoAtualizado);
    
                return Ok("O jogo foi atualizado");
            }


            /// <summary>
            /// Para cadastrar um novo Jogo
            /// </summary>
            /// <param name="novoJogo"></param>
            /// <returns>null</returns>
            [ProducesResponseType(StatusCodes.Status201Created)]
            [Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Post(JogoDomain novoJogo)
            {
               _jogoRepository.Cadastrar(novoJogo);

                return Created("Jogo cadastrado com sucesso", novoJogo);
            }
            
            /// <summary>
            /// Para deletar um usuario
            /// </summary>
            /// <param name="id"></param>
            /// <returns>null</returns>
            [Authorize(Roles = "1")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [HttpDelete("{id}")]
             public IActionResult Delete(int id)
             {
                _jogoRepository.Deletar(id);
                 return Ok("Jogo removido");
             }


            /// <summary>
            /// Para listar todos os jogos
            /// </summary>
            /// <returns>Lista de Jogos</returns>
            [ProducesResponseType(StatusCodes.Status200OK)]
            [HttpGet]
             public IEnumerable<JogoDomain> Get()
             {
                 return _jogoRepository.Listar();
             }



        }
    }
    