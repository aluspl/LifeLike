namespace Api.Models.Link
{
    public class LinkRequestModel
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int Order { get; set; }

        public string IconName { get; set; }

        public string Category { get; set; }

        public string YoutubeId { get; set; }
    }
}
