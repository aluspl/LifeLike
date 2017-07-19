using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Repositories;
using LifeLike.Utils;

namespace LifeLike.ViewModel
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
                Created = model.Created,
                Camera = model.Camera,
                FileName=model.FileName,
                Url = Path.Combine(PhotoRepository.PhotoPath, model.FileName),
                GalleryId=model.Gallery.Id
            };
        }



       
    }
    
}