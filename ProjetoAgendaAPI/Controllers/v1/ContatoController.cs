using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;

namespace ProjetoAgendaAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        /// <summary>
        /// GET: api/v1/Contato/{id_usuario}
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("{id_usuario}")]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContato(int id_usuario)
        {
            if (id_usuario <= 0)
                return BadRequest();

            IEnumerable<Contato> listaContato = await _contatoRepository.ObterTodosContatos(id_usuario);

            if (listaContato == null || listaContato.Count() == 0)
                return NotFound();

            return Ok(listaContato);
        }

        /// <summary>
        /// GET: api/v1/Contato/{id}/{id_usuario}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("{id}/{id_usuario}")]
        public async Task<ActionResult<Contato>> GetContato(int id, int id_usuario)
        {
            if (id <= 0 || id_usuario <= 0)
                return BadRequest();

            Contato contato = await _contatoRepository.ObterContato(id, id_usuario);

            if (contato == null || contato.Id == 0)
                return NotFound();

            return contato;
        }

        /// <summary>
        /// PUT: api/v1/Contato/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contato"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutContato(int id, [FromBody] Contato contato)
        {
            if (id != contato.Id)
                return BadRequest();

            TryValidateModel(contato);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (_contatoRepository.Atualizar(contato).Result)
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
        /// POST: api/v1/Contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Contato> PostContato([FromBody] Contato contato)
        {
            if (contato == null)
                return BadRequest();

            TryValidateModel(contato);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contatoRepository.Cadastrar(contato);
            return CreatedAtAction("GetContato", new { id = contato.Id }, contato);
        }

        /// <summary>
        /// DELETE: api/v1/Contato/{id}/{id_usuario}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{id_usuario}")]
        public ActionResult<Contato> DeleteContato(int id, int id_usuario)
        {
            if (_contatoRepository.Excluir(id, id_usuario))
                return Ok();
            else
                return NotFound();
        }
    }
}
