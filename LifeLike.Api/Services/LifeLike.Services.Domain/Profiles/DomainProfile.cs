using AutoMapper;
using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Entities.Link;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Entities.Photo;
using LifeLike.Services.Commons.Models.Config;
using LifeLike.Services.Commons.Models.Link;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Domain.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PageEntity, PageWriteModel>();
            CreateMap<PageWriteModel, PageEntity>();
            CreateMap<PhotoEntity, PhotoWriteModel>();
            CreateMap<PhotoWriteModel, PhotoEntity>();
            CreateMap<ContentEntity, ContentReadModel>();
            CreateMap<ContentReadModel, ContentEntity>();
            CreateMap<ConfigEntity, ConfigReadModel>();
            CreateMap<ConfigWriteModel, ConfigEntity>();
            CreateMap<LinkEntity, LinkReadModel>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
            CreateMap<LinkWriteModel, LinkEntity>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
        }
    }
}
