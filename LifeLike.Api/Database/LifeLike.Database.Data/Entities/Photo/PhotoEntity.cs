namespace LifeLike.Database.Data.Entities.Photo
{
    public class PhotoEntity : BaseEntity
    {
        public string Url { get; set; }

        public string ThumbUrl { get; set; }

        public string Filename { get; set; }

        public string ThumbFilename { get; set; }
    }
}
