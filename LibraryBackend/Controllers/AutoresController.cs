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
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public AutoresController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Autor>> Get()
        {
            return await context.Autores.ToListAsync();
        }

    }
}
