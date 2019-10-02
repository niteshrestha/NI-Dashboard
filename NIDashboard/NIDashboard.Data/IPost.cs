using NIDashboard.Data.Models;
using NIDashboard.Data.Models.spModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface IPost
    {
        SpPostDetail GetById(string id);
        IEnumerable<SpLatestPost> GetLatestPost(int n);
        IEnumerable<SpLatestPost> Search(string searchQuery);
        IEnumerable<SpLatestPost> SearchByTag(string searchQuery);
        IEnumerable<SpLatestPost> SearchByContent(string searchQuery);

        Task Add(Post post);
        Task Delete(string id);
    }
}
