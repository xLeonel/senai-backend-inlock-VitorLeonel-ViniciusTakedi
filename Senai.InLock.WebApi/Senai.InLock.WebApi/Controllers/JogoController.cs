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

            //-----------------------------------------Atualiza um jogo passando o seu id na url
            //[Authorize(Roles = "1")]
            [HttpPut("{id}")]
            public IActionResult PutIdUrl(int id, JogoDomain jogoAtualizado)
            {
                _jogoRepository.AtualizarJogoIdUrl(id, jogoAtualizado);
    
                return Ok("O jogo foi atualizado");
            }


            //-----------------------------------------Para cadastrar um novo Jogo
            [ProducesResponseType(StatusCodes.Status201Created)]
            //[Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Post(JogoDomain novoJogo)
            {
               _jogoRepository.Cadastrar(novoJogo);

                return Created("Jogo cadastrado com sucesso", novoJogo);
            }
            
            //-----------------------------------------Para deletar um usuario
            //[Authorize(Roles = "1")]
            [HttpDelete("{id}")]
             public IActionResult Delete(int id)
             {
                _jogoRepository.Deletar(id);
                 return Ok("Jogo removido");
             }


            //-----------------------------------------Para listar todos os jogos
            [HttpGet]
             public IEnumerable<JogoDomain> Get()
             {
                 return _jogoRepository.Listar();
             }



        }
    }
    