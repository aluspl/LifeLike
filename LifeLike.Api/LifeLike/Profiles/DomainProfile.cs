using System;
using AutoMapper;
using LifeLike.Models.Category;
using LifeLike.Models.Config;
using LifeLike.Models.Content;
using LifeLike.Models.Link;
using LifeLike.Models.Page;
using LifeLike.Models.Photo;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Config;
using LifeLike.Services.Commons.Models.Link;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PageRequestModel, PageWriteModel>()
                .ForMember(x => x.ShortName, d => d.MapFrom(src => src.ShortName.ToLower()));
            CreateMap<PageReadModel, PageResponseModel>();
            CreateMap<PhotoRequestModel, PhotoWriteModel>();
            CreateMap<PhotoReadModel, PhotoResponseModel>();
            CreateMap<ContentRequestModel, ContentWriteModel>();
            CreateMap<ContentReadModel, ContentResponseModel>();

            CreateMap<ConfigReadModel, ConfigResponseModel>();
            CreateMap<ConfigRequestModel, ConfigWriteModel>();

            CreateMap<CategoryReadModel, CategoryResponseModel>();
            CreateMap<CategoryRequestModel, CategoryWriteModel>();

            CreateMap<LinkReadModel, LinkResponseModel>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
            CreateMap<LinkRequestModel, LinkWriteModel>()
                .ForMember(x => x.Category, d => d.MapFrom(src => src.Category.ToString()));
        }
    }
}
