namespace BlogPost.Model.DTO
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Text { get; set; }
    }
}
