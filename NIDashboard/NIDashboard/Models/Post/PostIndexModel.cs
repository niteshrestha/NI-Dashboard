using System;

namespace NIDashboard.Models.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string PostContent { get; set; }
        public DateTime Created { get; set; }
        public string SectionName { get; set; }
        public int SectionId { get; set; }
    }
}
