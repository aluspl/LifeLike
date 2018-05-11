using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Web.Controllers;
using LifeLike.Web.ViewModel;

namespace LifeLike.Web.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Page, PageViewModel>();
            CreateMap<PageViewModel, Page>();
             CreateMap<EventLog, EventLogViewModel>();
            CreateMap<EventLogViewModel, EventLog>();
            CreateMap<Video, VideoViewModel>();
            CreateMap<VideoViewModel, Video>();


        }
    }
}