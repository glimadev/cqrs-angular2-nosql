using AutoMapper;
using cqrs_angular2_nosql.Domain.Models;
using cqrs_angular2_nosql.VM.Out;

namespace cqrs_angular2_nosql.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientDetailOutVM>();
            Mapper.CreateMap<Client, ClientListOutVM>();
        }
    }
}