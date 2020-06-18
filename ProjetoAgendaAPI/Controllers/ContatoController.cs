using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;

namespace ProjetoAgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        /// <summary>
        /// GET: api/Contato/{id_usuario}
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("{id_usuario}")]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContato(int idUsuario)
        {
            return await _contatoRepository.ObterTodosContatos(idUsuario);
        }

        /// <summary>
        /// GET: api/Contato/{id}/{id_usuario}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("{id}/{id_usuario}")]
        public async Task<ActionResult<Contato>> GetContato(int id, int idUsuario)
        {
            var contato = await _contatoRepository.ObterContato(id, idUsuario);

            if (contato == null)
                return NotFound();

            return contato;
        }

        /// <summary>
        /// PUT: api/Contato/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contato"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutContato(int id, Contato contato)
        {
            if (id != contato.Id)
                return BadRequest();

            try
            {
                if(_contatoRepository.Atualizar(contato).Result)
                    return Ok();
                else
                    return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// POST: api/Contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Contato> PostContato(Contato contato)
        {
            _contatoRepository.Cadastrar(contato);
            return CreatedAtAction("GetContato", new { id = contato.Id }, contato);
        }

        /// <summary>
        /// DELETE: api/Contato/{id}/{id_usuario}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("{id}/{id_usuario}")]
        public ActionResult<Contato> DeleteContato(int id, int idUsuario)
        {
            if (_contatoRepository.Excluir(id, idUsuario))
                return Ok();
            else
                return NotFound();
        }
    }
}
