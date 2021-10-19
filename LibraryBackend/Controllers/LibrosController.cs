using LibraryBackend.DTO;
using LibraryBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public LibrosController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Libro>> Get()
        {
            return await context.Libros.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var existe = await context.Libros.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound($"No existe el libro con el id {id}");

            return await context.Libros.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(LibroCreacionDTO libroCreacionDTO)
        {
            var autoresIdsExistentes = await (from l in context.Autores where libroCreacionDTO.AutoresIds.Contains(l.Id) select l.Id).ToListAsync();

            if(autoresIdsExistentes.Count != libroCreacionDTO.AutoresIds.Count)
            {
                return BadRequest("Algunos ids de autores no existen");
            }
            //await context.Libros.AddAsync(libro);
            //await context.SaveChangesAsync();
            return Ok();

        }
    }
}
