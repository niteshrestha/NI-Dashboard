using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NIDashboard.Data.Models;
using NIDashboard.Data.Models.spModels;

namespace NIDashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<SliderConfig> SliderConfigs { get; set; }
        public DbSet<SpLatestPost> SpLatestPosts { get; set; }
        public DbSet<SpPostDetail> SpPostDetails { get; set; }
        public DbSet<SpSectionWithPost> SpSectionWithPosts { get; set; }
    }
}
