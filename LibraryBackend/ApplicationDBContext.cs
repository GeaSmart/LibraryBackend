using LibraryBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AutorLibro>().HasKey(x => new { x.AutorId, x.LibroId });
        }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<AutorLibro> AutorLibro { get; set; }

    }
}
