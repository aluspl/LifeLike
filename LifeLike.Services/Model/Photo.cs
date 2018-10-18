using System;
using System.IO;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Services;

namespace LifeLike.Services.ViewModel
{
    public class Photo
    {
        public long Id { get; set; }
       
        public string Title { get; set; }

        public string Url { get=> Path.Combine(PhotoService.PhotoPath, FileName); }
        public string FileName { get; set; }

        public string ThumbUrl { get; set; }
        
        public DateTime Created { get; set; }
        public string Camera { get; set; }
        public  virtual GalleryEntity Gallery { get; set; }
        public long GalleryId { get; set; }

        public static Photo Get(PhotoEntity model)
        {
            return new Photo
            {
                Title = model.Title,
                Id=model.Id,
                Created = model.Created,
                Camera = model.Camera,
                FileName = model.FileName,
                GalleryId=model.Gallery.Id
            };
        }



       
    }
    
}