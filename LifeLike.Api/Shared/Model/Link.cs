namespace LifeLike.Shared.Model
{
    public class Link
    {
        public string Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        
        public string Name { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public string IconName { get; set; }

        public string Category { get; set; }
        public bool IsLink => (!string.IsNullOrEmpty(Url) && string.IsNullOrEmpty(Controller));
        public string YoutubeId { get; set; }
 
    }    
}