using LifeLike.Database.Data.Entities;
using LifeLike.Database.Data.Entities.Link;
using LifeLike.Database.Data.Entities.Page;
using LifeLike.Database.Data.Entities.Photo;
using LifeLike.Services.Commons.Models.Category;
using LifeLike.Services.Commons.Models.Config;
using LifeLike.Services.Commons.Models.Link;
using LifeLike.Services.Commons.Models.Page;
using LifeLike.Services.Commons.Models.Photo;
using LifeLike.Services.Commons.Models.Video;

namespace LifeLike.Services.Domain.Profiles;

public static class DomainExtensions
{
    #region Links

    public static LinkModel Map(this LinkEntity model)
    {
        return new LinkModel()
        {
            Name = model.Name,
            Order = model.Order,
            Url = model.Url,
            Controller = model.Controller,
            IsExternal = model.IsExternal,
            Action = model.Action,
            IconName = model.IconName,
            Category = model.Category,
            Id = model.Id,
        };
    }

    #endregion

    #region Config

    public static ConfigModel Map(this ConfigEntity model)
    {
        return new ConfigModel()
        {
            Name = model.Name,
            Id = model.Id,
            DisplayName = model.DisplayName,
            Value = model.Value,
            Type = model.Type,
        };
    }

    #endregion

    #region Page

    public static PageModel Map(this PageEntity model)
    {
        return new PageModel()
        {
            Id = model.Id,
            Order = model.Order,
            Summary = model.Summary,
            Categories = model.Categories.Select(x => x.Map()).ToList(),
            Contents = model.Contents.Select(x => x.Map()).ToList(),
            FullName = model.Fullname,
            ShortName = model.Shortname,
            Image = model.Image?.Map(),
            Published = model.Published ?? DateTime.MinValue,
        };
    }

    #endregion

    #region Page

    public static CategoryEntity Map(this CategoryWriteModel model)
    {
        return new CategoryEntity()
        {
            Order = model.Order,
            Name = model.Name,
        };
    }

    public static CategoryModel Map(this CategoryEntity model)
    {
        return new CategoryModel()
        {
            Id = model.Id,
            Order = model.Order,
            Name = model.Name,
        };
    }

    #endregion

    #region Photos

    public static ContentModel Map(this ContentEntity model)
    {
        return new ContentModel()
        {
            Id = model.Id,
            Url = model.Url,
            Name = model.Name,
            Category = model.Category,
            Content = model.Content,
            Image = model.Image?.Map(),
        };
    }

    #endregion
    #region Photos

    public static PhotoModel Map(this ImageEntity model)
    {
        return new PhotoModel()
        {
            Id = model.Id,
            ThumbnailFilename = model.ThumbnailFilename,
            ThumbnailUrl = model.ThumbnailUrl,
            Filename = model.Filename,
            Url = model.Url,
        };
    }

    #endregion
}