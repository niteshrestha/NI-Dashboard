using NIDashboard.Models.Section;

namespace NIDashboard.Models.Post
{
    public class PostListingModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string DatePosted { get; set; }
        public string Ago { get; set; }
        public string SectionTitle { get; set; }
        public int SectionId { get; set; }
        public SectionListingModel Section { get; set; }
    }
}