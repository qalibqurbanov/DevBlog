namespace DevBlog.Core.Entities
{
    /// <summary>
    /// Her bir post teqini temsil edir.
    /// </summary>
    public class Tag
    {
        public int    ID   { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}