using Microsoft.EntityFrameworkCore;
using Movie_Cart.Data.Base;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        
        public ActorsService(AppDbContext db): base(db) {  }
        
       
    }
}
