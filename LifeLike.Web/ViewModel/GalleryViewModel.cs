using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Http;

namespace LifeLike.Web.ViewModel
{
    public class GalleryViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }

        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public string ShortTitle { get; set; }

        public static UploadFileViewModel GetViewForUpload(Gallery model)
        {
            return new UploadFileViewModel
            {
                GalleryTitle=model.Title,
                GalleryId=model.Id,             
            };
        }

        public static Gallery Get(GalleryViewModel model)
        {
            if (model == null) return null;
            return new Gallery
            {
                ShortTitle=model.ShortTitle,
                Id=model.Id,
                Title       = model.Title,
                Created = model.Created,
                Description =  model.Description,
                Place = model.Place,
            };
        }
        public static GalleryViewModel Get(Gallery model)
        {
            if (model == null) return null;
            return new GalleryViewModel()
            {
                Id=model.Id,
                ShortTitle = model.ShortTitle,
                Title       = model.Title,
                Created = model.Created,
                Description =  model.Description,
                Place = model.Place,
                Photos = GetPhotoViewModels(model),
                SelectedPhoto=GetSelectedPhoto(model)

            };
        }

        private static IEnumerable<PhotoViewModel> GetPhotoViewModels(Gallery model)
        {
            return model.Photos?.Select(PhotoViewModel.Get) ?? new List<PhotoViewModel>();
        }

        private static string GetSelectedPhoto(Gallery model)
        {
            var selectedPhoto = model?.Photos?.FirstOrDefault() != null
                ? PhotoViewModel.Get(model.Photos.FirstOrDefault()).Url
                : Path.Combine(PhotoRepository.PhotoPath, "logo.png");
 
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