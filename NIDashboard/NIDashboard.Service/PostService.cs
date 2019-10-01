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
            _context.Database.ExecuteSqlCommand(
                $"spCreatePost {post.Id}, {post.Title}, {post.Content}, {post.Created}, {post.Tags}, {post.User.Id}, {post.Section.Id}");
        }

        public async Task Delete(string id)
        {
            _context.Database.ExecuteSqlCommand($"spDeletePost {id}");
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Section);
        }

        public Post GetById(string id)
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
