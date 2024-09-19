using AutoMapper;
using TestLibraryBackend.Models;
using TestLibraryBackend.DTOs;

namespace TestLibraryBackend {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}