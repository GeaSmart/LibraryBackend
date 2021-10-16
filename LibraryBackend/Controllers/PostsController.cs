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
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public PostsController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await context.Posts.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Post> Get(int id)
        {
            return await context.Posts.FirstOrDefaultAsync(x=>x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Post post)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Post post)
        {
            if (id != post.Id)
                return BadRequest("Los id no coinciden");
            var existe = await context.Posts.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound("El post que se quiere actualizar no existe");

            context.Posts.Update(post);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            context.Posts.Remove(new Post { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
