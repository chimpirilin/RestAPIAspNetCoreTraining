namespace RestApi.DBContext;
using Microsoft.EntityFrameworkCore;
using RestApi.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Products> Products { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<OrdersDetails> OrdersDetails { get; set; }
}
