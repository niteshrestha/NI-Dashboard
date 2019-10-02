using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using NIDashboard.Data.Models.spModels;
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

        public SpPostDetail GetById(string id)
        {
            return _context.SpPostDetails.FromSql($"spGetPostDetail {id}").FirstOrDefault();
        }

        public IEnumerable<SpLatestPost> GetLatestPost(int n)
        {
            return _context.SpLatestPosts.FromSql($"spGetLatestPost {n}").ToList();
        }

        public IEnumerable<SpLatestPost> Search(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.SpLatestPosts.FromSql($"spSearch {query}").ToList();
        }

        public IEnumerable<SpLatestPost> SearchByTag(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.SpLatestPosts.FromSql($"spSearchByTag {query}").ToList();
        }

        public IEnumerable<SpLatestPost> SearchByContent(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.SpLatestPosts.FromSql($"spSearchByContent {query}").ToList();
        }
    }
}
