using NIDashboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetLatestPost(int n);
        IEnumerable<Post> Search(string searchQuery);
        IEnumerable<Post> SearchByTag(string searchQuery);
        IEnumerable<Post> SearchByContent(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPost(int id, string newContent);
    }
}
