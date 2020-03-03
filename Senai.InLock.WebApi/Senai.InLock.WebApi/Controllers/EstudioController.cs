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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }


        //Atualiza um estudio passando o seu id na url
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            _estudioRepository.AtualizarEstudioIdUrl(id, estudioAtualizado);

            return Ok();
        }



        //Para cadastrar um novo Estudio
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
             _estudioRepository.Cadastrar(novoEstudio);

            return Created("Criado",novoEstudio);
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);
            return Ok("Estudio removido");
        }

        [HttpGet]
        public IEnumerable<EstudioDomain> Get()
        {
            return _estudioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            EstudioDomain estudio =  _estudioRepository.BuscarId(id);
            return Ok(estudio);
        }
    }
}
