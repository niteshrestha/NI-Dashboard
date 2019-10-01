using System;

namespace NIDashboard.Data.Models.spModels
{
    public class SpLatestPost
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public string SectionTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
