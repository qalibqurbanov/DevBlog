namespace DevBlog.Core.Entities
{
    /// <summary>
    /// Her bir postu temsil edir.
    /// </summary>
    public class Post
    {
        public int      ID                   { get; set; }
        public string   Title                { get; set; }
        public string   Content              { get; set; }
        public string   ShortDescription     { get; set; }
        public string   PostTumbnailImageUrl { get; set; }
        public string   PostUrl              { get; set; }
        public DateTime PublishedDate        { get; set; }
        public string   Author               { get; set; }
        public bool     IsDeleted            { get; set; }

        public int      CategoryID { get; set; }
        public Category Category   { get; set; }

        //public ICollection<PostTag>      PostTags       { get; set; }
    }
}