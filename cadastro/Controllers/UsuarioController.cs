using cadastro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            return new List<UsuarioModel>
            {
                new UsuarioModel { Id = 1, Nome = "Joao", Email = "Joao@example.com", Cep = "12345678" }
            };
        }
    }
}