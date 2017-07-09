using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LifeLike.Models;
using LifeLike.Models.Enums;
using LifeLike.Utils;

namespace LifeLike.ViewModel
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

        public static Gallery Get(GalleryViewModel model)
        {
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
            return new GalleryViewModel()
            {
                Id=model.Id,
                ShortTitle = model.ShortTitle,
                Title       = model.Title,
                Created = model.Created,
                Description =  model.Description,
                Place = model.Place,
                Photos = model.Photos!=null ? model.Photos.Select(PhotoViewModel.Get) : new List<PhotoViewModel>()

            };
        }
    }
}