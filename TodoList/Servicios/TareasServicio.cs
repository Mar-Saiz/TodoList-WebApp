using Microsoft.EntityFrameworkCore;
using TodoList.Context;
using TodoList.Interfaces;
using TodoList.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoList.Servicios
{
    public class TareasServicio : ITareas
    {
        private readonly Contexto _bd;

        public TareasServicio(Contexto bd)
        {
            _bd = bd;
        }
        public void ActualizarTarea(string nombreoriginal, string comentariooriginal,string nuevocomentario, 
            DateTime nuevafechainicio, DateTime nuevafechafinal, string nuevoestado)
        {
            var tarea= BuscarTarea(nombreoriginal, comentariooriginal);

            tarea.Comentario = nuevocomentario;
            tarea.FechaInicio = @nuevafechainicio;
            tarea.FechaFinal = @nuevafechafinal;
            tarea.Estado = nuevoestado;

            var tareaactualizada = _bd.Tareas.Find(tarea.idtarea);

            if(tareaactualizada != null)
            {
                tareaactualizada.Comentario = tarea.Comentario;
                tareaactualizada.FechaInicio = tarea.FechaInicio;
                tareaactualizada.FechaFinal = tarea.FechaFinal;
                tareaactualizada.Estado = tarea.Estado;

            }

            _bd.SaveChanges();

        }
        public Tareas BuscarTarea(string nombre, string comentario)
        {
            var tarea = _bd.Tareas.FirstOrDefault(t => t.Nombre == nombre || t.Comentario == comentario);

            if(tarea != null)
            {
                return tarea;
            }
            else
            {
                Console.WriteLine("La tarea no existe");
                return null;
            }

           
        }
        public void CrearTarea(Tareas tarea)
        {
            try
            {
                _bd.Tareas.Add(tarea);

                _bd.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void EliminarTarea(string nombre, string comentario)
        {
            var tareaeliminada = _bd.Tareas.FirstOrDefault(t => t.Nombre == nombre || t.Comentario == comentario);

            if(tareaeliminada != null)
            {
                _bd.Tareas.Remove(tareaeliminada);
                _bd.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error");
            }
        }
        public List<Tareas> ListarTareas()
        {
            List<Tareas> todaslastareas = _bd.Tareas.ToList();

            return todaslastareas;
        }
    }
}
