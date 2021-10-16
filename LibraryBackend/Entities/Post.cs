using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Titulo { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Contenido { get; set; }

        [Column(TypeName = "Datetime")]
        [Required]
        public DateTime FechaPublicacion { get; set; }

        public int AutorId { get; set; }

        //Propiedades de navegación
        public Autor Autor { get; set; }
    }
}
