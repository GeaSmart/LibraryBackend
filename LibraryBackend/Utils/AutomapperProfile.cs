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
            CreateMap<LibroCreacionDTO, Libro>();
        }
    }
}
