using AutoMapper;
using LibraryOn.Communication.Requests.Genres;
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

    }

    private void EntityToResponse()
    {
        CreateMap<Genre, ResponseRegisteredGenreJson>();
    }
}
