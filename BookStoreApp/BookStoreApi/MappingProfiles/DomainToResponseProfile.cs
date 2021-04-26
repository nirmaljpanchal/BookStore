using AutoMapper;
using BookStoreApi.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel , Book>();

        }
    }
}
