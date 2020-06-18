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

        // GET: api/Contato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContato()
        {
            return await _contatoRepository.ObterTodosContatos();
        }

        // GET: api/Contato/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContato(int id)
        {
            var contato = await _contatoRepository.ObterContato(id);

            if (contato == null)
                return NotFound();

            return contato;
        }

        // PUT: api/Contato/{id}
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

        // POST: api/Contato
        [HttpPost]
        public ActionResult<Contato> PostContato(Contato contato)
        {
            _contatoRepository.Cadastrar(contato);
            return CreatedAtAction("GetContato", new { id = contato.Id }, contato);
        }

        // DELETE: api/Contato/{id}
        [HttpDelete("{id}")]
        public ActionResult<Contato> DeleteContato(int id)
        {
            if (_contatoRepository.Excluir(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
