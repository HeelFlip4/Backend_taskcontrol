using cadastro.Models;
using cadastro.Repositorios;
using cadastro.Repositorios.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _usuarioRepositorio = UsuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
	        List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
	        return Ok(usuarios);
        }

        [HttpGet("buscarpor/{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
	        UsuarioModel usuarios = await _usuarioRepositorio.BuscarPorId(id);
	        return Ok(usuarios);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
    }
}