using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = GetById(id);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public Task EditPost(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Section);
        }

        public Post GetById(int id)
        {
            return _context.Posts
                .Where(post => post.Id == id)
                .Include(post => post.User)
                .Include(post => post.Section)
                .FirstOrDefault();
        }

        public IQueryable<Post> GetLatestPost(int n)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(n);
        }

        public IEnumerable<Post> Search(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Section)
                .Where(post => post.Tags.ToLower().Contains(query)
                || post.Content.ToLower().Contains(query)
                || post.Title.ToLower().Contains(query));
        }

        public IEnumerable<Post> SearchByTag(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Section)
                .Where(post => post.Tags.ToLower().Contains(query));
        }

        public IEnumerable<Post> SearchByContent(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Section)
                .Where(post => post.Content.ToLower().Contains(query));
        }
    }
}
