using AutoMapper;
using SelfServicePump.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Agents, DTO.AgentDTO>().ReverseMap();
            CreateMap<DTO.AgentCreationDTO, Entities.Agents>();

            CreateMap<Entities.Customers, DTO.CustomerDTO>().ReverseMap();
            CreateMap<DTO.CustomerCreationDTO, Entities.Customers>();


        }

    }
}