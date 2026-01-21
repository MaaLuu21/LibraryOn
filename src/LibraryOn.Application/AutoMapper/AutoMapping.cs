using AutoMapper;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.ValueObjects;

namespace LibraryOn.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping() 
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestGenreJson, Genre>();
        CreateMap<RequestBookJson, Book>();
        CreateMap<RequestReaderJson, Reader>();

    }

    private void EntityToResponse()
    {
        //Genre
        CreateMap<Genre, ResponseGenreJson>();
        CreateMap<Genre, ResponseRegisteredGenreJson>();

        //Book
        CreateMap<Book, ResponseRegisteredBookJson>();
        CreateMap<Book, ResponseShortBookJson>();
        CreateMap<Book, ResponseBookJson>();

        //reader
        CreateMap<Reader, ResponseRegisteredReaderJson>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        CreateMap<Reader, ResponseShortReaderJson>();
        CreateMap<Reader, ResponseReaderJson>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

    }
}
