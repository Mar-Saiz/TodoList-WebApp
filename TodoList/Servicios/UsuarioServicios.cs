using System.Text;
using Microsoft.IdentityModel.Tokens;
using TodoList.Context;
using TodoList.Interfaces;
using TodoList.Modelos;

namespace TodoList.Servicios
{
    public class UsuarioServicios : IUsuarios
    {
        private readonly Contexto bd;

        public UsuarioServicios(Contexto bd)
        {
            this.bd = bd;
        }

        // Metodos para simplificar los servicios
        public string CifrarContrasenia(string contrasenia)
        {
            var contraseniabytes = System.Text.Encoding.UTF8.GetBytes(contrasenia);

            return System.Convert.ToBase64String(contraseniabytes);

        }
        public bool ValidarLogin(string correo, string contrasenia)
        {
            //Encuentrar al usuario que coincida con los parametros
            var validacion = bd.Usuarios.Any(u => u.correo == correo || u.contrasenia == contrasenia);

            return validacion;
        }

        // Servicios del controlador
        public Usuarios LoginUser(string correo, string contrasenia)
        {
            var contraseniaenbd =CifrarContrasenia(contrasenia);

            if (ValidarLogin(correo, contraseniaenbd))
            {   
                // Devolver al ususio encontrado si validacion es verdadera

                var usuarioencontrado = bd.Usuarios.FirstOrDefault(u => u.correo == correo 
                || u.contrasenia == contraseniaenbd);

                return usuarioencontrado;
            }
            else
            {
                Console.WriteLine(" El usuario no existe, debe de registrarse");

                return null;
            }      
        }
        public void RegistrarUser(Usuarios newusuario)
        {
            var Ucontrasenia = newusuario.contrasenia;

            newusuario.contrasenia= CifrarContrasenia(Ucontrasenia);

            bd.Usuarios.Add(newusuario);

                bd.SaveChanges();
        }
    }
}
