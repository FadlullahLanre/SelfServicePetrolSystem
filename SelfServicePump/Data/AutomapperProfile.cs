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
            CreateMap<DTO.AgentCreationDTO, Agents>();

            CreateMap<Customers, DTO.CustomerDTO>();
            CreateMap<DTO.CustomerCreationDTO, Customers>();

            CreateMap<User, DTO.UserDTO>();
            CreateMap<DTO.UserCreationDTO, User>();


        }

    }
}