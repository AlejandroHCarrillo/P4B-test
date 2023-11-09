namespace api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public string Resume => Content.Length < 70 ? Content: Content.Substring(1,70);
    }
}
