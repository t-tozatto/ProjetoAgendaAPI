﻿using System.Collections.Generic;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// GET: api/v1/Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            IEnumerable<Usuario> listaUsuario = await _usuarioRepository.ObterTodosUsuarios();

            if (listaUsuario == null || listaUsuario.Count() == 0)
                return NotFound();

            return Ok(listaUsuario);
        }

        /// <summary>
        /// GET: api/v1/usuario/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (id <= 0)
                return BadRequest();

            Usuario usuario = await _usuarioRepository.ObterUsuario(id);

            if (usuario == null || usuario.Id == 0)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// GET: api/v1/usuario/{nome}/{senha}
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet("{nome}/{senha}")]
        public async Task<ActionResult<Usuario>> Login(string nome, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
                return BadRequest();

            Usuario usuario = await _usuarioRepository.Login(nome, senha);

            if (usuario == null || usuario.Id == 0)
                return NotFound();

            return usuario;
        }

        /// <summary>
        /// PUT: api/v1/usuario/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            TryValidateModel(usuario);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
        /// POST: api/v1/usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Usuario> PostUsuario([FromBody] Usuario usuario)
        {
            if(usuario == null)
                return BadRequest();

            TryValidateModel(usuario);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _usuarioRepository.Cadastrar(usuario);
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// DELETE: api/v1/usuario/{id}
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