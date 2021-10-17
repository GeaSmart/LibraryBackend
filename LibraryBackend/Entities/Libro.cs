using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Entities
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Titulo { get; set; }

        //propiedades de navegación
        public List<AutorLibro> AutoresLibros { get; set; }

    }
}
