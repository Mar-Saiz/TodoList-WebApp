using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Modelos
{
    public class Tareas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idtarea {get; set;}
         public string Nombre {get; set;}
         public string Comentario {get; set;}
         public DateTime FechaInicio {get; set;}
         public DateTime FechaFinal {get; set;}
         public string Estado {get; set;}


        [ForeignKey("Usuario")]
        public int idUsuarios { get; set; }
    }
}
