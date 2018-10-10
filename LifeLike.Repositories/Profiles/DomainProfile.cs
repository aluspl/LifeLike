using System;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Data.Models.Enums;
using LifeLike.Repositories.Extensions;
using LifeLike.Repositories.ViewModel;

namespace LifeLike.Repositories.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PageEntity, Page>();
            CreateMap<Page, PageEntity>();
            CreateMap<PhotoEntity, Photo>();
            CreateMap<Photo, PhotoEntity>();
            CreateMap<EventLogEntity, Log>();
            CreateMap<Log, EventLogEntity>();
            CreateMap<VideoEntity, Video>();
            CreateMap<Video, VideoEntity>();
            CreateMap<ConfigEntity, Config>();
            CreateMap<Config, ConfigEntity>();
            CreateMap<LinkEntity, Link>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
            CreateMap<Link, LinkEntity>()
                .ForMember(x => x.Category, d => d.ResolveUsing(src=> src.Category.ToEnum(LinkCategory.Menu)));
        }    
    }
}