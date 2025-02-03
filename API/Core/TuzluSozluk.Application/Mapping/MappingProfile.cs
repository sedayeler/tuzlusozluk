using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Common.Models.RequestModels;
using TuzluSozluk.Domain.Entities;

namespace TuzluSozluk.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginUserCommandRequest, User>().ReverseMap();
        }
    }
}
