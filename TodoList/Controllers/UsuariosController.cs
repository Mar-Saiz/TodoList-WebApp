using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoList.Interfaces;
using TodoList.Modelos;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios servicio;


        public UsuariosController(IUsuarios servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost("Crear_Usuario")]
        public void GetNewUsuario([FromBody] Usuarios usuario)
        {
            servicio.RegistrarUser(usuario);
        }

        [HttpGet("Login_Usuario")]
        public IActionResult GetUser(string correo, string contrasenia)
        {
            var usuariologin = servicio.LoginUser(correo, contrasenia);


            return Ok(usuariologin);
        }

    }
}
