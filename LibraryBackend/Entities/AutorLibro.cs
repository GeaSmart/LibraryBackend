using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Entities
{
    public class AutorLibro
    {
        public int AutorId { get; set; }

        public int LibroId { get; set; }
        
        [Required]
        public int Orden { get; set; }

        //Propiedades de navegación
        public Autor Autor { get; set; }
        public Libro Libro { get; set; }
    }
}
