using AutoMapper;
using LibraryAPI.BLL.Models;
using LibraryAPI.DAL.Models;

namespace LibraryAPI.BLL.Mapping
{
	public class BookMappingProfile : Profile
	{
        public BookMappingProfile()
        {
            CreateMap<Book, GetBookDTO>();
            CreateMap<CreateBookDTO, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0));
            CreateMap<UpdateBookDTO, Book>();
        }
    }
}
