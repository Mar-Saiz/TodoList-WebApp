using System.Threading;
using TodoList.Modelos;

namespace TodoList.Interfaces
{
    public interface ITareas
    {
        void CrearTarea(Tareas tarea);
        void ActualizarTarea(string nombre, string comentario, string nuevocomentario,
            DateTime nuevafechainicio, DateTime nuevafechafinal, string nuevoestado);
        void EliminarTarea(string nombre, string comentario);
        List<Tareas> ListarTareas();
        Tareas BuscarTarea(string nombre, string comentario);


    }
}
