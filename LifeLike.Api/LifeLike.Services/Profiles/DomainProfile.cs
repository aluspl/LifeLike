using System;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Services.Extensions;
using LifeLike.Services.ViewModel;
using LifeLike.Shared.Enums;
using LifeLike.Shared.Models;

namespace LifeLike.Services.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PageEntity, Page>()
               .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
            CreateMap<Page, PageEntity>()
              .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToEnum<PageCategory>(PageCategory.Page)));
            CreateMap<PhotoEntity, Photo>();
            CreateMap<Photo, PhotoEntity>();
            CreateMap<EventLogEntity, Log>();
            CreateMap<Log, EventLogEntity>();
            CreateMap<VideoEntity, Video>()
              .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));

            CreateMap<Video, VideoEntity>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToEnum<VideoCategory>(VideoCategory.VLOG)));

            CreateMap<ConfigEntity, Config>();
            CreateMap<Config, ConfigEntity>();
            CreateMap<LinkEntity, Link>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
            CreateMap<Link, LinkEntity>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
        }    

    }
}