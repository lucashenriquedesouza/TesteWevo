using AutoMapper;
using TesteWevo.Application.Domain.DTOs.Entities;
using TesteWevo.Application.Domain.DTOs.Requests;
using TesteWevo.Application.Domain.DTOs.Responses;

namespace TesteWevo.Application.Domain.Mappers
{

    public class PersonMapper : Profile
    {

        public PersonMapper()
        {

            CreateMap<PersonSaveRequest, PersonEntity>().ReverseMap();
            CreateMap<PersonResponse, PersonEntity>().ReverseMap();
            CreateMap<PersonSaveRequest, PersonResponse>().ReverseMap();

        }

    }

}
