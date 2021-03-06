﻿using AutoMapper;
using cqrs_angular2_nosql.Domain.Commands;
using cqrs_angular2_nosql.VM.In;

namespace cqrs_angular2_nosql.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ClientInsertInVM, RegisterClientCommand>();
            Mapper.CreateMap<ClientUpdateInVM, UpdateClientCommand>();
        }
    }
}