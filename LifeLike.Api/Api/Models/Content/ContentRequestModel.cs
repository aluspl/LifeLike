using System;
using LifeLike.Common.Enums;

namespace Api.Models.Content
{
    public class ContentRequestModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public ContentCategory Category { get; set; }

        public Guid? ImageId { get; set; }

    }
}
