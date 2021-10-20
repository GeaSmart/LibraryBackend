using AutoMapper;
using LibraryBackend.DTO;
using LibraryBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBackend.Utils
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(x => x.AutoresLibros, options => options.MapFrom(MapAutoresLibros));
        }

        private List<AutorLibro> MapAutoresLibros(LibroCreacionDTO libroCreacionDTO, Libro libro)
        {
            var resultado = new List<AutorLibro>();

            if (libroCreacionDTO.AutoresIds == null)
                return resultado;

            foreach(int id in libroCreacionDTO.AutoresIds)
            {
                resultado.Add(new AutorLibro { AutorId = id });
            }

            return resultado;
        }
    }
}
