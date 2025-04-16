using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Interfaces;
using TodoList.Modelos;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareas servicio;

        public TareasController(ITareas servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost("Crear_Tarea")]
        public void GetNewTarea([FromBody] Tareas tarea)
        {
            servicio.CrearTarea(tarea);
        }
        
        [HttpPut("Actualizar_Tarea")]
        public void GetOldTarea(string nombreoriginal, string comentariooriginal, string nuevocomentario, 
            DateTime fechainicio,DateTime fechafinal, string estado)
        {
           servicio.ActualizarTarea(nombreoriginal, comentariooriginal, nuevocomentario, fechainicio, fechafinal, estado);
        }

        [HttpGet ("Todas_tareas")]
        public IActionResult PostAllTareas()
        {
            var listatareas =servicio.ListarTareas();

            return Ok(listatareas);
        }

        [HttpGet("Buscar_Tarea")]
        public IActionResult PostATareas(string nombre, string comentario)
        {
            var tarea = servicio.BuscarTarea(nombre, comentario);

            return Ok(tarea);
        }

        [HttpDelete("Borrar_Tarea")]
        public void DeleteTarea(string nombre, string comentario)
        {
            servicio.EliminarTarea(nombre, comentario);
        }
    }
}
