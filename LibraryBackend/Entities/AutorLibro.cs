using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Entities
{
    public class AutorLibro
    {
        [Key]
        public int AutorId { get; set; }

        [Key]
        public int LibroId { get; set; }

        [Required]
        public int Orden { get; set; }

        //Propiedades de navegación
        public Autor Autor { get; set; }
        public Libro Libro { get; set; }
    }
}
