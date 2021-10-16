using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]        
        [Required]
        public string Nombre { get; set; }
    }
}
