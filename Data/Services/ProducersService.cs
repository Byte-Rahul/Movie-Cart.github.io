using Movie_Cart.Data.Base;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext db) : base(db)
        {
        }
    }
}
