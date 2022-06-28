using Microsoft.EntityFrameworkCore;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _db { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext db)
        {
            _db = db;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId",cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _db.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId=ShoppingCartId,
                    Movie=movie,
                    Amount=1

                };
                _db.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _db.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _db.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
               
                if(shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _db.ShoppingCartItems.Remove(shoppingCartItem);
                }
                
            }
            
            _db.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _db.ShoppingCartItems.Where(n => n.ShoppingCartId == 
            ShoppingCartId).Include(n => n.Movie).ToList());
        }
        public double GetShoppingCartTotal() => _db.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum(); 
        
        public async Task ClearShoppingCartAsync()
        {
            var items = await _db.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).ToListAsync();
            _db.ShoppingCartItems.RemoveRange(items);
            await _db.SaveChangesAsync();
        }
    }
}
