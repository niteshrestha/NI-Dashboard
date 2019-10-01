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
        IEnumerable<Post> Search(string searchQuery);
        IEnumerable<Post> SearchByTag(string searchQuery);
        IEnumerable<Post> SearchByContent(string searchQuery);

        Task Add(Post post);
        Task Delete(string id);
    }
}
