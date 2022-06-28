using Movie_Cart.Data.Base;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext db) : base(db)
        {
        }
    }
}
