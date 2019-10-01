using System;
using System.Collections.Generic;
using System.Text;

namespace NIDashboard.Data.Models.spModels
{
    public class SpPostDetail
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Tags { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SectionId { get; set; }
        public string SectionTitle { get; set; }
    }
}
