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

        /// <summary>
        /// GET: api/Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _usuarioRepository.ObterTodosUsuarios();
        }

        /// <summary>
        /// GET: api/Usuario/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObterUsuario(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        /// <summary>
        /// GET: api/Usuario/{nome}/{senha}
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet("{nome}/{senha}")]
        public async Task<ActionResult<Usuario>> Login(string nome, string senha)
        {
            var usuario = await _usuarioRepository.Login(nome, senha);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        /// <summary>
        /// PUT: api/Usuario/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// POST: api/Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// DELETE: api/Usuario/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
