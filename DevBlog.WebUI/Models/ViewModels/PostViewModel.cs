namespace DevBlog.WebUI.Models.ViewModels
{
    public class PostViewModel
    {
        public string   Title                { get; set; }
        public string   Content              { get; set; }
        public string   ShortDescription     { get; set; }
        public string   PostTumbnailImageUrl { get; set; }
        public string   PostUrl              { get; set; }
        public DateTime PublishedDate        { get; set; }
        public string   Author               { get; set; }
    }
}