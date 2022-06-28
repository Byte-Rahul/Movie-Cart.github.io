using Microsoft.EntityFrameworkCore;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _db;
        public OrdersService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _db.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n=>n.User).ToListAsync();
            if(userRole!=null)
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId=userId,
                Email=userEmailAddress,
            };
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount=item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId=order.Id,
                    Price=item.Movie.Price
                };
                await _db.OrderItems.AddAsync(orderItem);
            }
            await _db.SaveChangesAsync();
        }
    }
}
