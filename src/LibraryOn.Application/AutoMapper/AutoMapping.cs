using AutoMapper;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Domain.Entities;

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

    }

    private void EntityToResponse()
    {
        CreateMap<Genre, ResponseRegisteredGenreJson>();
        CreateMap<Book, ResponseRegisteredBookJson>();
    }
}
