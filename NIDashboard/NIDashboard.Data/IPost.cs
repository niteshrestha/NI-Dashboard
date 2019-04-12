using NIDashboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostBySection(int id);
        IEnumerable<Post> GetLatestPost(int n);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPost(int id, string newContent);
    }
}
