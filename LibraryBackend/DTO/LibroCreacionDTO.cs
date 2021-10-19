using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.DTO
{
    public class LibroCreacionDTO
    {
        [Display(Name ="Titulo del libro")]
        [StringLength(maximumLength: 50)]
        public string Titulo { get; set; }

        public List<int> AutoresIds { get; set; }

    }
}
