using AutoMapper;
using Inide.WebServices.Application.RequestModels;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.Persistence.Common;
using Inide.WebServices.Persistence.Domain;


namespace Inide.WebServices.Infrastructure.Mapping
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Evento, CreateEventoRequest>().ReverseMap();
            CreateMap<Evento, UpdateEventoRequest>().ReverseMap();
            CreateMap<Evento, EventoResponse>().ReverseMap();
        }
    }
}
