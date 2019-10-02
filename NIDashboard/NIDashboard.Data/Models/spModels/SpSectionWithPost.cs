using System;
using System.Collections.Generic;
using System.Text;

namespace NIDashboard.Data.Models.spModels
{
    public class SpSectionWithPost
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int SectionId { get; set; }
        public string Tags { get; set; }
        public string PostTitle { get; set; }
        public string SectionTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
