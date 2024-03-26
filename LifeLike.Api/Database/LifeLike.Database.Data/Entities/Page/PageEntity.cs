using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities.Link;
using LifeLike.Database.Data.Entities.Photo;

namespace LifeLike.Database.Data.Entities.Page;

public class PageEntity : BaseEntity
{
    public PageEntity()
    {
        Categories = new List<CategoryEntity>();
        Contents = new List<ContentEntity>();
    }

    public PageEntity(string shortname, string fullname)
        : base()
    {
        Shortname = shortname;
        Fullname = fullname;
    }

    public string Shortname { get; set; }

    public string Fullname { get; set; }

    public int Order { get; set; }

    public DateTime? Published { get; set; }

    public ICollection<CategoryEntity> Categories { get; set; }

    public ICollection<ContentEntity> Contents { get; set; }

    public LinkEntity Link { get; set; }

    public Guid? LinkId { get; set; }

    public ImageEntity Image { get; set; }

    public Guid? ImageId { get; set; }

    public string Summary { get; set; }

    #region Public Methods

    #region Publish

    public void Publish()
    {
        Published = DateTime.UtcNow;
    }

    public void CancelPublish()
    {
        Published = null;
    }

    public void SetImage(Guid imageId)
    {
        ImageId = imageId;
    }

    public void RemoveImage()
    {
        ImageId = null;
    }

    public void AddContent(ContentEntity content)
    {
        Contents.Add(content);
    }

    public void RemoveContent(Guid id)
    {
        if (Contents.Any(p => p.Id == id))
        {
            throw new NotFoundException($"Content with {id} not found");
        }

        var toRemove = Contents.FirstOrDefault(p => p.Id == id);
        Contents.Remove(toRemove);
    }

    public void AddCategory(CategoryEntity category)
    {
        Categories.Add(category);
    }

    public void RemoveCategory(Guid id)
    {
        if (Categories.Any(p => p.Id == id))
        {
            throw new NotFoundException($"Category with {id} not found");
        }

        var categoryToRemove = Categories.FirstOrDefault(p => p.Id == id);
        Categories.Remove(categoryToRemove);
    }
    #endregion

    #endregion

    public static PageEntity New(string shortname, string fullname) => new PageEntity(shortname, fullname);
}