using System.Collections.Generic;

namespace NIDashboard.Data.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
