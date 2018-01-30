using System;
using System.IO;
using LifeLike.Data.Models;
using LifeLike.Repositories;

namespace LifeLike.Web.ViewModel
{
    public class PhotoViewModel
    {
        public long Id { get; set; }
       
        public string Title { get; set; }

        public string Url { get; set; }
        public string FileName { get; set; }

        public string ThumbUrl { get; set; }
        
        public DateTime Created { get; set; }
        public string Camera { get; set; }
        public  virtual Gallery Gallery { get; set; }
        public long GalleryId { get; set; }

        public static PhotoViewModel Get(Photo model)
        {
            return new PhotoViewModel
            {
                Title = model.Title,
                Id=model.Id,
                Created = model.Created,
                Camera = model.Camera,
                FileName=model.FileName,
                Url = Path.Combine(PhotoRepository.PhotoPath, model.FileName),
                GalleryId=model.Gallery.Id
            };
        }



       
    }
    
}