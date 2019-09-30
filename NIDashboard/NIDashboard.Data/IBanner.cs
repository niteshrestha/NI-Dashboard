using NIDashboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIDashboard.Data
{
    public interface IBanner
    {
        Banner GetById(int id);
        IEnumerable<Banner> GetAll();
        Task Add(Banner banner);
        Task Delete(int id);

    }
}
