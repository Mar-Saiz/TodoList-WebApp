using TodoList.Modelos;

namespace TodoList.Interfaces
{
    public interface IUsuarios
    {
        void RegistrarUser(Usuarios newusuario);
        Usuarios LoginUser(string correo, string contrasenia);

    }
}
