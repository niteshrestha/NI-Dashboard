using Microsoft.EntityFrameworkCore;
using NIDashboard.Data;
using NIDashboard.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Service
{
    public class BannerService : IBanner
    {
        private readonly ApplicationDbContext _context;
        public BannerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Banner banner)
        {
            _context.Database.ExecuteSqlCommand($"spAddBanner {banner.Name}");
        }

        public async Task Delete(int id)
        {
            _context.Database.ExecuteSqlCommand($"spDeleteBanner {id}");
        }

        public IEnumerable<Banner> GetAll()
        {
            return _context.Banners.FromSql("spGetBanners");
        }
    }
}
