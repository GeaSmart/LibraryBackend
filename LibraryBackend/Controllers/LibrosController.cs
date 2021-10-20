using AutoMapper;
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
        private readonly IMapper mapper;

        public LibrosController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
            if (libroCreacionDTO.AutoresIds == null)
                return BadRequest("No se envió ningún autor");
            
            var autoresIdsExistentes = await (from l in context.Autores where libroCreacionDTO.AutoresIds.Contains(l.Id) select l.Id).ToListAsync();

            if (autoresIdsExistentes.Count != libroCreacionDTO.AutoresIds.Count)
                return BadRequest("Algunos ids de autores no existen");            

            var libro = mapper.Map<Libro>(libroCreacionDTO);

            if(libro.AutoresLibros != null)
            {
                for(int i = 0; i < libro.AutoresLibros.Count; i++)
                {
                    libro.AutoresLibros[i].Orden = i;
                }
            }

            await context.Libros.AddAsync(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
