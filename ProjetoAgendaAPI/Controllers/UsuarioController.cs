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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _usuarioRepository.ObterTodosUsuarios();
        }

        // GET: api/Usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObterUsuario(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        // GET: api/Usuario/{nome}/{senha}
        [HttpGet("{nome}/{senha}")]
        public async Task<ActionResult<Usuario>> Login(string nome, string senha)
        {
            var usuario = await _usuarioRepository.Login(nome, senha);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        // PUT: api/Usuario/{id}
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            try
            {
                if (_usuarioRepository.Atualizar(usuario).Result)
                    return Ok();
                else
                    return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuario/{5}
        [HttpDelete("{id}")]
        public ActionResult<Usuario> DeleteUsuario(int id)
        {
            if (_usuarioRepository.Excluir(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
