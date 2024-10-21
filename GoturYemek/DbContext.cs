using GoturYemek.Models;
using Microsoft.EntityFrameworkCore;

public class YemekSiparisDbContext : DbContext
{
    public YemekSiparisDbContext(DbContextOptions<YemekSiparisDbContext> options) : base(options)
    {
    }

    
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }  // Restoranlar
    public DbSet<Food> Foods { get; set; }  

    public DbSet<OrderItem> OrderItems { get; set; }
    


}
