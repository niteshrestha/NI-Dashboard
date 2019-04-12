using NIDashboard.Data;
using NIDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NIDashboard.Service
{
    public class PostService : IPost
    {
        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPost(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPost(int n)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostBySection(int id)
        {
            throw new NotImplementedException();
        }
    }
}
