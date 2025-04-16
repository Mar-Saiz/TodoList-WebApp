using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Modelos
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarios { get; set; }
        public  string NombreUsuario { get; set; }
        public string correo { get; set; }
        public string contrasenia { get; set; }
    }
}
