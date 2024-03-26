namespace LifeLike.Database.Data.Entities.Page;

public class CategoryEntity : BaseEntity
{
    public CategoryEntity()
    {
        Pages = new List<PageEntity>();
    }

    public string Name { get; set; }

    public int Order { get; set; }

    public ICollection<PageEntity> Pages { get; set; }
}