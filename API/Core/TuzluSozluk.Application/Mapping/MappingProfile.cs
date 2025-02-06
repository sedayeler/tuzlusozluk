using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.DTOs;
using TuzluSozluk.Application.Features.Commands.LoginUser;
using TuzluSozluk.Domain.Entities;

namespace TuzluSozluk.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<LoginUserCommandRequest, User>().ReverseMap();      
        }
    }
}
