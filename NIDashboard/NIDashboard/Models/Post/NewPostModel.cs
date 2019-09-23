namespace NIDashboard.Models.Post
{
    public class NewPostModel
    {
        public string SectionName { get; set; }
        public int SectionId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}
