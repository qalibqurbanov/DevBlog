namespace DevBlog.Core.Entities
{
    /// <summary>
    /// Her bir post kateqoriyasini temsil edir.
    /// </summary>
    public class Category
    {
        public int    ID   { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}