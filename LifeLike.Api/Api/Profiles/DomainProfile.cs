using System;
using Api.Models.Category;
using Api.Models.Config;
using Api.Models.Content;
using Api.Models.Link;
using Api.Models.Page;
using Api.Models.Photo;
using AutoMapper;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Config;
using LifeLike.Services.Commons.Models.Link;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Commons.Models.Video;

namespace Api.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PageRequestModel, PageWriteModel>()
                .ForMember(x => x.Published, d => d.MapFrom(src => DateTime.UtcNow));
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
