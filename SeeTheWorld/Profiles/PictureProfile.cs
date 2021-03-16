using System;

using AutoMapper;
using SeeTheWorld.Dto;
using SeeTheWorld.Entities;

namespace SeeTheWorld.Profiles
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<PictureDto, PictureEntity>()
                .ForMember(dest => dest.DumpTime,
                    opt => opt
                        .MapFrom(src => src.DumpTime == new DateTime() 
                            ? DateTime.Now 
                            : src.DumpTime
                        )
                );

            CreateMap<PictureEntity, PictureDto>();
        }
    }
}
