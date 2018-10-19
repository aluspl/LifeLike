using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Services;
using Microsoft.AspNetCore.Http;

namespace LifeLike.Services.ViewModel
{
    public class Album
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }

        public IEnumerable<Photo> Photos { get; set; }
        public string ShortTitle { get; set; }

        public static UploadFileViewModel GetViewForUpload(Album model)
        {
            return new UploadFileViewModel
            {
                GalleryTitle=model.Title,
                GalleryId=model.Id             
            };
        }


        private static IEnumerable<Photo> GetPhotoViewModels(Album model)
        {
            return model.Photos ?? new List<Photo>();
        }

        private static string GetSelectedPhoto(Album model)
        {
            var selectedPhoto = model?.Photos?.FirstOrDefault() != null
                ?model.Photos.FirstOrDefault().Url
                : Path.Combine(PhotoService.PhotoPath, "logo.png");
 
            return selectedPhoto;
        }

        public string SelectedPhoto { get; set; }
    }

    public class UploadFileViewModel
    {
        public IFormFile Photo { get; set; }

        public long GalleryId { get; set; }
        public string GalleryTitle { get; set; }
        public string Title { get; set; }
    }
}